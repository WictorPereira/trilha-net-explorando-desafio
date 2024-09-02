namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
           if (Suite == null)
            {
                throw new InvalidOperationException("A suíte deve ser cadastrada antes de adicionar hóspedes.");
            }

            if (hospedes.Count > Suite.Capacidade)
            {
                throw new InvalidOperationException("A quantidade de hóspedes excede a capacidade da suíte.");
            }
            
            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("A suíte deve ser cadastrada para calcular o valor da diária.");
            }

            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Aplicar desconto de 10% se a reserva for de 10 dias ou mais
            if (DiasReservados >= 10)
            {
                valor *= 0.9m; // 10% de desconto
            }

            return valor;
        }
    }
}