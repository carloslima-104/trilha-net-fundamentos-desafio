using System.Reflection.Metadata.Ecma335;
using Microsoft.Win32.SafeHandles;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.Write("Digite a placa do veículo para estacionar: ");
            string placa = Console.ReadLine();
            
            if (string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("A placa não pode ser vazia.");
                return;
            }

            if (veiculos.Contains(placa))
            {
                Console.WriteLine($"O veículo com a placa {placa} já está estacionado.");
                return;
            }

            veiculos.Add(placa);
            Console.WriteLine("Veículo adicionado com sucesso!");
            
        }
        

        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover: ");
            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                if (!int.TryParse(Console.ReadLine(), out int horas))
                {
                    Console.WriteLine("Valor inválido para a quantidade de horas.");
                    return;
                }

                decimal valorTotal = CalcularValorTotal(horas);
                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:C}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        private decimal CalcularValorTotal(int horas)
        {
            return precoInicial + precoPorHora * horas;
        }
        

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");   

            }
        }
    }
}
