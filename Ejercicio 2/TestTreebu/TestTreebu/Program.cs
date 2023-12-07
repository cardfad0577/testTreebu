// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;

class CuentaBancaria
{
    public string Cliente { get; set; }
    public string Documento { get; set; }
    public string TipoCuenta { get; set; }
    public decimal Saldo { get; set; }
    public List<(string, string, decimal, decimal)> Movimientos { get; set; }

    public CuentaBancaria(string cliente, string documento, string tipoCuenta, decimal saldoInicial = 0)
    {
        Cliente = cliente;
        Documento = documento;
        TipoCuenta = tipoCuenta;
        Saldo = saldoInicial;
        Movimientos = new List<(string, string, decimal, decimal)>();
    }

    public void Consignar(string fecha, decimal monto)
    {
        Saldo += monto;
        Movimientos.Add((fecha, "Consignación", monto, Saldo));
    }

    public void Retirar(string fecha, decimal monto)
    {
        if (Saldo >= monto)
        {
            Saldo -= monto;
            Movimientos.Add((fecha, "Retiro", monto, Saldo));
        }
        else
        {
            Console.WriteLine("Saldo insuficiente.");
        }
    }

    public void ImprimirMovimientos()
    {
        var movimientosOrdenados = Movimientos.OrderBy(m => DateTime.ParseExact(m.Item1, "dd/MM/yyyy", CultureInfo.InvariantCulture));
        foreach (var movimiento in movimientosOrdenados)
        {
            Console.WriteLine($"Fecha: {movimiento.Item1}, Operación: {movimiento.Item2}, Monto: {movimiento.Item3}, Saldo Final: {movimiento.Item4}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Crear cuenta bancaria para Carlos Avila
        CuentaBancaria cuentaCarlos = new CuentaBancaria("Carlos Avila", "12234455", "Cuenta de ahorros", 10000);

        // Realizar consignaciones y retiros
        cuentaCarlos.Consignar("01/05/2020", 9800000);
        cuentaCarlos.Retirar("02/05/2020", 10000000);
        cuentaCarlos.Consignar("03/05/2020", 10000000);
        cuentaCarlos.Retirar("04/05/2020", 10000000);
        cuentaCarlos.Consignar("05/05/2020", 10000000);
        cuentaCarlos.Retirar("06/05/2020", 10000000);

        // Imprimir detalle de movimientos ordenado por fecha
        Console.WriteLine("Detalle de Movimientos:");
        cuentaCarlos.ImprimirMovimientos();
    }
}