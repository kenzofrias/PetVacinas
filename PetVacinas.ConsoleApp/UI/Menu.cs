using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetVacinas.Core.Interfaces;
using PetVacinas.Core.Models;
using PetVacinas.Core.Services;

namespace PetVacinas.ConsoleApp.UI
{
    public class Menu
    {
        private readonly AnimalService _animalService;
        private readonly VacinaService _vacinaService;
        public Menu()
        {
            _animalService = new AnimalService();
            _vacinaService = new VacinaService();
        }

        public void Iniciar()
        {
            int opcao = 0;
            while (opcao != 7)
            {
                Console.Clear();
                ExibirMenu();
                opcao = ValidarOpcao(ReceberOpcao());
                VerificarOpcao(opcao);
                if (opcao != 7)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        public void ExibirMenu()
        {
            Console.WriteLine("=============  MENU PET-VACINAS  =============");
            Console.WriteLine("1 - Cadastrar animal");
            Console.WriteLine("2 - Listar todos os animais");
            Console.WriteLine("3 - Cadastrar vacina");
            Console.WriteLine("4 - Listar todas as vacinas");
            Console.WriteLine("5 - Registrar vacinação em um animal");
            Console.WriteLine("6 - Exibir histórico de vacinações de um animal");
            Console.WriteLine("7 - Sair");
        }

        public int ReceberOpcao()
        {
            while (true)
            {
                Console.Write("Escolha uma opção: ");
                bool sucesso = int.TryParse(Console.ReadLine(), out int opcaoConvertida);

                if (sucesso)
                {
                    return opcaoConvertida;
                }

                Console.WriteLine("[ERRO] Opção deve ser um número da lista.");
            }
        }

        public int ReceberInteiro(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                if (int.TryParse(Console.ReadLine(), out int valor))
                {
                    return valor;
                }
                
                Console.WriteLine("[ERRO] Valor inválido. Digite um número inteiro.");
            }
        }

        public int ValidarOpcao(int opcao)
        {
            while (opcao < 1 || opcao > 7)
            {
                Console.WriteLine("[ERRO] Opção deve ser um número entre 1 e 7.");
                opcao = ReceberOpcao();
            }
            return opcao;
        }

        public void VerificarOpcao(int opcao)
        {
            try
            {
                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Informações do animal: ");
                        Console.Write("Nome do animal: ");
                        string nomeAnimal = Console.ReadLine()!.Trim();
                        Console.Write("Raça do animal: ");
                        string raca = Console.ReadLine()!.Trim();
                        Console.Write("Dono do animal: ");
                        string dono = Console.ReadLine()!.Trim();

                        Animal novoAnimal = new Animal(nomeAnimal, raca, dono);
                        var animal = _animalService.CadastrarAnimal(novoAnimal);
                        Console.WriteLine($"{novoAnimal.Nome} foi cadastrado (a) com sucesso!");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Animais cadastrados no sistema: ");
                        IEnumerable<IAnimal> animais = _animalService.ObterTodosAnimais();
                        foreach (IAnimal animalAtual in animais)
                        {
                            Console.WriteLine(animalAtual.ToString());
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("informações da vacina:");
                        Console.Write("Nome da vacina: ");
                        string nomeVacina = Console.ReadLine()!.Trim();
                        Console.Write("Fabricante da vacina: ");
                        string fabricante = Console.ReadLine()!.Trim();

                        Vacina novaVacina = new Vacina(nomeVacina, fabricante);
                        var vacina = _vacinaService.CadastrarVacina(novaVacina);
                        Console.WriteLine($"{vacina.Nome} foi cadastrada com sucesso!");
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Vacinas cadastradas no sistema: ");
                        IEnumerable<IVacina> vacinas = _vacinaService.ObterTodasVacinas();
                        foreach (IVacina vacinaAtual in vacinas)
                        {
                            Console.WriteLine(vacinaAtual.ToString());
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Registrar vacinação em um animal: ");
                        Console.Write("Responsável pela aplicação: ");
                        string responsavel = Console.ReadLine()!.Trim();

                        Console.WriteLine("\nVacinas disponíveis no sistema: ");
                        IEnumerable<IVacina> vacinasExistentes = _vacinaService.ObterTodasVacinas();
                        foreach (IVacina vacinaAtual in vacinasExistentes)
                        {
                            Console.WriteLine(vacinaAtual.ToString());
                        }
                            int idVacinaAplicada = ReceberInteiro("Vacina aplicada (informe o ID): ");
                        IVacina vacinaAplicada = _vacinaService.ObterVacinaPorId(idVacinaAplicada);

                        Console.WriteLine("\nAnimais cadastrados no sistema: ");
                        IEnumerable<IAnimal> animaisCadastrados = _animalService.ObterTodosAnimais();
                        foreach (IAnimal animalAtual in animaisCadastrados)
                        {
                            Console.WriteLine(animalAtual.ToString());
                        }
                            int idAnimalV = ReceberInteiro("Animal vacinado (informe o ID): ");

                        Vacinacao novaVacinacao = new Vacinacao(responsavel, vacinaAplicada);
                        var vacinacao = _animalService.RegistrarVacinacao(idAnimalV, novaVacinacao);
                        Console.WriteLine("Vacinação registrada com sucesso!");
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Animais cadastrados no sistema: ");
                        IEnumerable<IAnimal> animaisDisponiveis = _animalService.ObterTodosAnimais();
                        foreach (IAnimal animalAtual in animaisDisponiveis)
                        {
                            Console.WriteLine(animalAtual.ToString());
                        }
                        int idAnimalH = ReceberInteiro("Animal para exibir histórico (informe o ID): ");
                        IEnumerable<IVacinacao> vacinacoes = _animalService.ObterHistoricoDeVacinacoes(idAnimalH);
                        var animalEncontrado = _animalService.ObterAnimalPorId(idAnimalH);
                        
                        if (!vacinacoes.Any())
                        {
                            Console.WriteLine("\nNenhuma vacinação registrada para este animal.");
                        }
                        else
                        {
                            Console.WriteLine($"\nHistórico de vacinações de {animalEncontrado.Nome}: ");
                            foreach (IVacinacao vacinacaoAtual in vacinacoes)
                            {
                                Console.WriteLine(vacinacaoAtual.ToString());    
                            }
                        }
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Obrigado pela visita! Saindo...");
                        break;
                    default:
                        Console.WriteLine("[ERRO] Opção inválida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ERRO] Ação não concluída: {ex.Message}");
            }
        }
    }
}