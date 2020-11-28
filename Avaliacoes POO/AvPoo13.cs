using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace AvPoo13
{

    [Flags]
    public enum MenuEmp
    {
        Sair = 0,
        Laboratórios = 1,
        Salvar = 2
    }

    [Flags]
    public enum MenuLab
    {
        Voltar = 0,
        Inserir = 1,
        Medições = 2
    }

    [Flags]
    public enum MenuMed
    {
        Voltar = 0,
        Inserir = 1
    }

    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo ci = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = ci;

            Console.WriteLine("\nInforme o Id da Empresa\n-------------------------");
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            if (id <= 0) throw (new ArgumentOutOfRangeException());

            Empresa empresa = new Empresa();
            empresa.AbrirXml(id);

            MenuEmp op;

            while (true)
            {
                Console.WriteLine($"\n-------------------------------------------------\nEmpresa: {empresa.Descricao} ({empresa.Id})\n-------------------------------------------------");
                op = Form.MenuEmpresa();
                switch (op)
                {
                    case MenuEmp.Sair:
                        return;
                    case MenuEmp.Laboratórios:
                        Form.Laboratorios(empresa);
                        break;
                    case MenuEmp.Salvar:
                        empresa.SalvarXml();
                        break;
                    default:
                        continue;
                }
            }
        }
    }

    class Form
    {
        public static MenuEmp MenuEmpresa()
        {
            Console.WriteLine("\nDigite a opção:");
            Console.WriteLine(">0 Sair");
            Console.WriteLine(">1 Laboratórios");
            Console.WriteLine(">2 Salvar");
            Console.Write(">");
            return (MenuEmp)int.Parse(Console.ReadLine());
        }

        public static string NovaEmpresa(int _id)
        {
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            return descricao;
        }

        public static void Laboratorios(Empresa _empresa)
        {
            MenuLab op;

            while (true)
            {
                op = Form.MenuLaboratorio(_empresa);
                switch (op)
                {
                    case MenuLab.Voltar:
                        return;
                    case MenuLab.Inserir:
                        Laboratorio l = Form.NovoLaboratorio();
                        _empresa.Inserir(l);
                        break;
                    case MenuLab.Medições:
                        Form.Medicoes(Form.GetLaboratorio(_empresa));
                        break;
                    default:
                        continue;
                }
            }
        }

        public static MenuLab MenuLaboratorio(Empresa _empresa)
        {
            Console.WriteLine($"\n\n-------------------------------------------------\nLaboratórios da Empresa {_empresa.Descricao}\n-------------------------------------------------");
            foreach (Laboratorio l in _empresa.Listar())
                Console.WriteLine(l);
            Console.WriteLine("\nDigite a opção");
            Console.WriteLine(">0 Voltar");
            Console.WriteLine(">1 Novo Laboratório");
            Console.WriteLine(">2 Medições do laboratório");
            Console.Write(">");
            return (MenuLab)int.Parse(Console.ReadLine());
        }

        public static Laboratorio NovoLaboratorio()
        {
            Console.Write("\nId do Laboratório: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            return new Laboratorio { Id = id, Descricao = descricao };
        }

        public static Laboratorio GetLaboratorio(Empresa _empresa)
        {
            Console.Write("\nId: ");
            int id = int.Parse(Console.ReadLine());
            return _empresa.Labs.Find(x => x.Id == id);
        }

        public static void Medicoes(Laboratorio _laboratorio)
        {
            MenuMed op;

            while (true)
            {
                op = Form.MenuMedicao(_laboratorio);
                switch (op)
                {
                    case MenuMed.Voltar:
                        return;
                    case MenuMed.Inserir:
                        Medicao m = Form.NovaMedicao();
                        _laboratorio.Inserir(m);
                        break;
                    default:
                        continue;
                }
            }
        }

        public static MenuMed MenuMedicao(Laboratorio _laboratorio)
        {
            Console.WriteLine($"\n\n-------------------------------------------------\nMedições do laboratório {_laboratorio.Descricao}\n-------------------------------------------------");
            foreach (Medicao m in _laboratorio.Listar())
                Console.WriteLine(m);
            Console.WriteLine("\nDigite a opção");
            Console.WriteLine(">0 Voltar");
            Console.WriteLine(">1 Nova Medição");
            Console.Write(">");
            return (MenuMed)int.Parse(Console.ReadLine());
        }

        public static Medicao NovaMedicao()
        {
            Console.Write("\nData/Hora: ");
            DateTime horario = DateTime.Parse(Console.ReadLine());
            Console.Write("Temperatura (Celsius): ");
            double temperatura = double.Parse(Console.ReadLine());
            return new Medicao { Horario = horario, Temperatura = temperatura };
        }
}

public class Medicao
    {
        public DateTime Horario { get; set; }
        public double Temperatura { get; set; }

        public override string ToString()
        {
            return $"Data: {this.Horario}, Temperatura: {this.Temperatura} C.";
        }
    }

    public class Laboratorio
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Medicoes { get { return meds.Count; } }
        public List<Medicao> Meds { get { return meds; } }
        private List<Medicao> meds = new List<Medicao>();

        public void Inserir(Medicao m)
        {
            this.meds.Add(m);
            return;
        }

        public List<Medicao> Listar()
        {
            return meds;
        }

        public override string ToString()
        {
            return $"Laboratório: {this.Descricao}, Id: {this.Id}, Medições: {this.Medicoes}";
        }
    }

    public class Empresa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Laboratorios { get { return labs.Count; } }
        public List<Laboratorio> Labs { get { return labs; } }
        private List<Laboratorio> labs = new List<Laboratorio>();

        public void Inserir(Laboratorio lab)
        {
            this.labs.Add(lab);
            return;
        }

        public List<Laboratorio> Listar()
        {
            return labs;
        }

        public void AbrirXml(int _id)
        {
            string arquivo = "Empresa-" + _id + ".xml";
            Empresa empresa;

            XmlSerializer serializer = new XmlSerializer(typeof(Empresa));
            try
            {
                FileStream fs = new FileStream(arquivo, FileMode.Open);
                TextReader reader = new StreamReader(fs);
                empresa = (Empresa)serializer.Deserialize(reader);
                this.Id = empresa.Id;
                this.Descricao = empresa.Descricao;
                this.labs = empresa.labs;
                reader.Close();
            }
            catch (FileNotFoundException)
            {
                this.Id = _id;
                this.Descricao = Form.NovaEmpresa(_id);
                SalvarXml();
            }

            return;
        }

        public void SalvarXml()
        {
            XmlSerializer x = new XmlSerializer(typeof(Empresa));
            TextWriter tw = new StreamWriter("Empresa-" + this.Id + ".xml");
            x.Serialize(tw, this);
            tw.Close();
            return;
        }

        public override string ToString()
        {
            return $"Empresa: {this.Descricao}, Id: {this.Id}, Laboratórios: {this.Laboratorios}";
        }

    }
}
