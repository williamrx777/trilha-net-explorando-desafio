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
            // Verifica se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            if (hospedes == null || hospedes.Count == 0)
            {
                throw new ArgumentException("A lista de hóspedes não pode ser nula ou vazia.");
            }
            if (Suite == null)
            {
                throw new InvalidOperationException("A suíte deve ser cadastrada antes de cadastrar os hóspedes.");
            }
            if (hospedes.Count > Suite.Capacidade)
            {
                throw new ArgumentException("A quantidade de hóspedes excede a capacidade da suíte.");
            }

            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes (propriedade Hospedes)
            if (Hospedes == null)
            {
                return 0;
            }
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            if (Suite == null)
            {
                throw new InvalidOperationException("A suíte deve ser cadastrada antes de calcular o valor da diária.");
            }
            if (Hospedes == null || Hospedes.Count == 0)
            {
                throw new InvalidOperationException("A lista de hóspedes não pode ser nula ou vazia.");
            }

            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor *= 0.9m; // Aplica desconto de 10%
            }

            return valor;
        }
    }
}