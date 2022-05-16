using RotasDeViagem.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotasDeViagem.Infra.Data
{
    public class LendoMeuDB
    {
        private readonly string _caminhoBD = @"C:\projetos\Master\RotasDeViagem\base-rotas.csv";

        public List<Voo> ListarBD()
        {
            var bdCompleto = new List<Voo>();

            using (var reader = new StreamReader(File.OpenRead(_caminhoBD)))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    var escala = new List<Escala>();

                    if (string.IsNullOrEmpty(values[values.Length - 1]))
                        values = values.Where((source, index) => index != (values.Length - 1)).ToArray();

                    if (values.Length >= 4)
                    {
                        if (values.Length > 4)
                        {
                            var totalEscala = values.Length - 4;

                            var id = values[0];
                            var origem = values[1];

                            for (int i = 1; i <= totalEscala; i++)
                            {
                                escala.Add(new Escala() { Parada = values[1 + i] });
                            }

                            var destino = values[2 + totalEscala];
                            var valor = values[3 + totalEscala];

                            bdCompleto.Add(new Voo() { Id = Convert.ToInt32(id), Origem = origem, Destino = destino, Escalas = escala, Valor = valor });
                        }
                        else
                        {
                            var id = values[0];
                            var origem = values[1];
                            var destino = values[2];
                            var valor = values[3];
                            bdCompleto.Add(new Voo() { Id = Convert.ToInt32(id), Origem = origem, Destino = destino, Escalas = escala, Valor = valor });
                        }
                    }
                }
            }

            return bdCompleto;
        }
        public void Create(Voo voo, bool is_AdicionarLinha = true)
        {

            var ultimoId = ListarBD().OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            
            var textInsert = string.Empty;

            textInsert = InsertVoo(voo, ultimoId, is_AdicionarLinha);
        }

        private string InsertVoo(Voo voo,int ultimoId, bool is_AdicionarLinha = true)
        {
            var textEscala = string.Empty;
            string textInsert;

            if (voo.Escalas != null)
            {
                voo.Escalas.ForEach(t =>
                {
                    textEscala += string.Format("{0};", t.Parada.ToUpper());
                });
            }

            if (string.IsNullOrEmpty(textEscala))
                textInsert = string.Format("{0};{1};{2};{3}", ultimoId, voo.Origem.ToUpper(), voo.Destino.ToUpper(), voo.Valor);
            else
                textInsert = string.Format("{0};{1};{2};{3}{4}", ultimoId, voo.Origem.ToUpper(), voo.Destino.ToUpper(), textEscala, voo.Valor);

            using (var sw = new StreamWriter(_caminhoBD, is_AdicionarLinha, Encoding.UTF8))
            {
                sw.WriteLine(textInsert);
            }

            return textInsert;
        }

        public void Update(Voo voo)
        {
            var voos = ListarBD();
            
            var primeiroId = voos.ToList().OrderBy(y => y.Id).FirstOrDefault().Id;

            voos.OrderBy(x => x.Id).ToList().ForEach(t =>
            {
                if (t.Id == voo.Id)
                {
                    t.Destino = voo.Destino;
                    t.Origem = voo.Origem;
                    t.Valor = voo.Valor;

                    if (voo.Escalas != null)
                    {
                        t.Escalas = null;

                        var escala = new List<Escala>();
                        voo.Escalas.ForEach(x =>
                        {
                            escala.Add(new Escala() { Parada = x.Parada });
                        });

                        t.Escalas = escala;
                    }

                    voos.Remove(voos.Find(x => x.Id == voo.Id));
                }

                if (voos.Any(x => x.Id == primeiroId))
                {
                    InsertVoo(t, t.Id, false);
                    voos.Remove(voos.Find(x => x.Id == primeiroId));
                }
                else
                    InsertVoo(t, t.Id);

            });

        }

        public void Remove(Voo voo)
        {
            var voos = ListarBD();
            int primeiroId = voos.ToList().Where(t => t.Id != voo.Id).OrderBy(y => y.Id).FirstOrDefault().Id;

            voos.OrderBy(x => x.Id).ToList().ForEach(t =>
            {
                if (t.Id != voo.Id)
                {
                    if (voos.Any(x => x.Id == primeiroId))
                    {
                        InsertVoo(t, t.Id, false);
                        voos.Remove(voos.Find(x => x.Id == primeiroId));
                    }
                    else
                        InsertVoo(t, t.Id);
                }
            });
        }

    }
}

