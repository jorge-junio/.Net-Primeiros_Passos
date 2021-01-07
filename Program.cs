using System;

namespace introducao_dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0; //inferencia de tipo
            int nAlunos = 0;
            string op = Menu();

            while (op.ToUpper() != "X")
            {

                switch (op)
                {
                    case "1":
                        Console.WriteLine("Digite o nome do aluno:");
                        Aluno aluno = new Aluno(); 

                        aluno.Nome = Console.ReadLine();
                        
                        Console.WriteLine("Digite a nota do aluno;");
                        if(decimal.TryParse(Console.ReadLine(), out decimal nota)){
                            aluno.Nota = nota;
                        }else{
                            throw new ArgumentException();
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                    case "2":
                        nAlunos = 0;
                        Console.WriteLine("------------ LISTA DE ALUNOS ------------");
                        foreach (var a in alunos)
                        {   
                            if(!string.IsNullOrEmpty(a.Nome)){
                                ++nAlunos;
                                Console.WriteLine($"Aluno {nAlunos} - Nome: {a.Nome} e Nota: {a.Nota}");
                            }
                        }

                        if (nAlunos == 0)
                        {
                            Console.WriteLine("Não há alunos cadastrados!");
                        }
                        
                        Console.WriteLine("");
                        break;
                    case "3":
                        decimal media = 0;
                        nAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome)){
                                media += alunos[i].Nota;
                                nAlunos++;
                            }
                        }

                        if(nAlunos > 0){
                            media /= nAlunos;
                            ConceitoEnum conceitoGeral;

                            if(media < 2){
                                conceitoGeral = ConceitoEnum.E;
                            }else if(media < 4){
                                conceitoGeral = ConceitoEnum.D;
                            }else if(media < 6){
                                conceitoGeral = ConceitoEnum.C;
                            }else if(media < 8){
                                conceitoGeral = ConceitoEnum.B;
                            }else{
                                conceitoGeral = ConceitoEnum.A;
                            }

                            Console.WriteLine($"A média geral dos {nAlunos} alunos é: {media} e o conceito geral é: {conceitoGeral}");
                        }else{
                            Console.WriteLine("Não há alunos cadastrados!");
                        }

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                op = Menu();
            }
        }

        private static string Menu()
        {
            Console.WriteLine("------------ MENU ------------");
            Console.WriteLine("Informe a opção desejada!");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine("");

            Console.Write("Opção escolhida: ");
            string op = Console.ReadLine();
            Console.WriteLine("");
            return op;
        }
    }
}
