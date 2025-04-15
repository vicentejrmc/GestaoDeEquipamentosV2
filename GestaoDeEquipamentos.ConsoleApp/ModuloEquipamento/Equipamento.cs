﻿using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class Equipamento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Fabricante Fabricante { get; set; }
    public decimal PrecoAquisicao { get; set; }
    public DateTime DataFabricacao { get; set; }

    public string NumeroSerie
    {
        get
        {
            string tresPrimeirosCaracteres = Nome.Substring(0, 3).ToUpper();

            return $"{tresPrimeirosCaracteres}-{Id}";
        }
    }

    public Equipamento(string nome, decimal precoAquisicao, DateTime dataFabricacao, Fabricante fabricante)
    {
        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
        Fabricante = fabricante;
    }

    public string Validar()
    {
        string erros = "";

        if (Fabricante == null)
            erros += "O campo Fabricante é obrigatório.\n";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo Nome é obrigatório.\n";

        if (Nome.Length < 3)
            erros += "O campo Nome deve ter no mínimo 3 caracteres.\n";

        if (PrecoAquisicao <= 0)
            erros += "O campo Preço de Aquisição deve ser maior que zero.\n";

        if (DataFabricacao == DateTime.MinValue)
            erros += "O campo Data de Fabricação é obrigatório.\n";

        if (DataFabricacao > DateTime.Now)
            erros += "A data de fabricação não pode ser maior que a data atual.\n";


        return erros;
    }

}
