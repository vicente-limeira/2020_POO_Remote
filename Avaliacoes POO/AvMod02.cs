using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace AvPoo15
{

    [Flags]
    public enum Menu
    {
        Sair = 0,
        Inserir = 1,
        Remover = 2,
        Listar = 3,
        MaiorIra = 4,
        Salvar = 5
    }


    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo ci = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = ci;

            Console.WriteLine("\nInforme o código da turma\n-------------------------");
            Console.Write("#");
            string codigo = Console.ReadLine();

            if (codigo == "") throw (new ArgumentOutOfRangeException());

            Turma t = new Turma();
            t.AbrirXml(codigo);

            Menu op;

            while (true)
            {
                Console.WriteLine($"\n-------------------------------------------------\n{t}\n-------------------------------------------------");
                op = Form.Menu();
                switch (op)
                {
                    case Menu.Sair:
                        return;
                    case Menu.Inserir:
                        t.Inserir(Form.Inserir());
                        break;
                    case Menu.Remover:
                        Form.Remover(t);
                        break;
                    case Menu.Listar:
                        Form.Listar(t);
                        break;
                    case Menu.MaiorIra:
                        Console.WriteLine($"maior IRA: {t.MaiorIra()}");
                        break;
                    case Menu.Salvar:
                        t.SalvarXml();
                        break;
                    default:
                        continue;
                }
            }
        }
    }

    class Form
    {
        public static Menu Menu()
        {
            Console.WriteLine("0> Sair");
            Console.WriteLine("1> Inserir");
            Console.WriteLine("2> Remover");
            Console.WriteLine("3> Listar");
            Console.WriteLine("4> Maior IRA");
            Console.WriteLine("5> Salvar");
            return (Menu) int.Parse(Console.ReadLine());
        }

        public static Aluno Inserir()
        {
            Console.Write("\nNome: ");
            string nome = Console.ReadLine();
            Console.Write("Matrícula: ");
            string matricula = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("IRA: ");
            int ira = int.Parse(Console.ReadLine());

            Aluno a = new Aluno();
            a.Nome = nome;
            a.Matricula = matricula;
            a.Email = email;
            a.Ira = ira;

            return a;
        }

        public static string NovaTurma()
        {
            Console.Write("Curso: ");
            string curso = Console.ReadLine();
            return curso;
        }

        public static void Listar(Turma t)
        {
            Console.WriteLine($"Listando {t.Listar().Count} aluno(s).\n");
            foreach (Aluno a in t.Listar())
                Console.WriteLine(a);

            return;
        }

        public static void Remover(Turma t)
        {
            Console.Write("\nAluno: ");
            string nome = Console.ReadLine();

            Aluno a = t.Listar().Find(x => x.Nome == nome);
            if (a == null)
                Console.WriteLine("\n* Aluno não existe.");
            else
                t.Remover(a);

            return;
        }

    }

    public class Aluno : IComparable<Aluno>
    {
        private string nome, matricula, email;
        private int ira;

        public string Nome { get { return this.nome;  } set { this.nome = value; return; }  }
        public string Matricula { get { return this.matricula; } set { this.matricula = value; return; } }
        public string Email { get { return this.email; } set { this.email = value; return; } }
        public int Ira { get { return this.ira; } set { this.ira = value; return; } }

        public override string ToString()
        {
            return $"{this.nome}, {this.matricula}, {this.email}, {this.ira}";
        }

        public int CompareTo(Aluno obj)
        {
            return this.Nome.CompareTo(obj.Nome);
        }

    }

    class CompareIRA : IComparer<Aluno>
    {
        public int Compare(Aluno x, Aluno y)
        {
            return x.Ira.CompareTo(y.Ira);
        }
    }

    public class Turma
    {
        private string codigo, curso;
        private List<Aluno> alunos = new List<Aluno>();

        public string Codigo { get { return codigo; } }
        public string Curso { get { return curso; } }
        public List<Aluno> Alunos { get { return alunos; } }

        public void Inserir(Aluno a)
        {
            this.alunos.Add(a);
        }

        public void Remover(Aluno a)
        {
            this.alunos.Remove(a);
            return;
        }

        public List<Aluno> Listar()
        {
            return this.alunos;
        }

        public Aluno MaiorIra()
        {
            this.alunos.Sort(new CompareIRA());
            return this.alunos[this.alunos.Count - 1];
        }

        public void AbrirXml(string codigo)
        {
            string arquivo = "Turma-" + codigo + ".xml";
            Turma t;

            XmlSerializer serializer = new XmlSerializer(typeof(Turma));
            try
            {
                FileStream fs = new FileStream(arquivo, FileMode.Open);
                TextReader reader = new StreamReader(fs);
                t = (Turma)serializer.Deserialize(reader);
                this.codigo = t.codigo;
                this.curso = t.curso;
                this.alunos = t.alunos;
                reader.Close();
            }
            catch (FileNotFoundException)
            {
                this.codigo = codigo;
                this.curso = Form.NovaTurma();
                SalvarXml();
            }

            return;
        }

        public void SalvarXml()
        {
            XmlSerializer x = new XmlSerializer(typeof(Turma));
            TextWriter tw = new StreamWriter("Turma-" + this.Codigo + ".xml");
            x.Serialize(tw, this);
            tw.Close();
            return;
        }

        public override string ToString()
        {
            return $"Turma: ({this.codigo}) {this.curso}";
        }


    }

}
