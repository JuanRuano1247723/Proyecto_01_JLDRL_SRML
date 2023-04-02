using System;


namespace Proyecto_Final_JLDRL_SRML
{
    class Program
    {            
         static void Nombre()
            {
            Console.WriteLine("                  ___   ___                                                                                                                                                                ");
            Console.WriteLine("     /__  ___/       / /        //   / /     /|    / /     //    ) )     // | |     //   ) )       /|    //| |     // | |     //   ) )             //   / /     //   ) )      / /          ");
            Console.WriteLine("       / /          / /        //____       //|   / /     //    / /     //__| |    ((             //|   // | |    //__| |    ((                   //   / /     //___/ /      / /           ");
            Console.WriteLine("      / /          / /        / ____       // |  / /     //    / /     / ___  |      \\\\          // |  //  | |   / ___  |    \\\\        ____      //   / /     / ___ (       / /      ____  ");
            Console.WriteLine("     / /          / /        //           //  | / /     //    / /     //    | |        ) )      //  | //   | |  //    | |        ) )            //   / /     //   | |      / /             ");
            Console.WriteLine("    / /        __/ /___     //____/ /    //   |/ /     //____/ /     //     | | ((___ / /      //   |//    | | //     | | ((___ / /            ((___/ /     //    | |     / /____/ /       ");

            }
        public class Tiendamas
        {
            readonly string NomFac;
            readonly string NIT;
            private readonly string correo;
            private string codigoProducto;
            public int cantidadFacturas = 0, cantidadProducto = 0, cantidadPuntos = 0;
            public Tiendamas()
            {
                NomFac = "";
                NIT = "";
                correo = "";
                codigoProducto = "000";
            }
            public void Facturacion(string NomFac, string NIT, string correo)
            {
                int cant001 = 0, cant002 = 0, cant003 = 0, cant004 = 0, cant005 = 0;
                string codigoProducto;
                float precioProducto;
                float subtotal, total = 0;
                int puntos = 0;
                string opcion;
                Nombre();
                Console.WriteLine("**Código**    **Producto**        **Precio**");
                Console.WriteLine("---001---     Libra de Azúcar     Q.10.80 \n");
                Console.WriteLine("---002---     Libra de Arroz      Q.3.80 \n");
                Console.WriteLine("---003---     Galleta GAMA        Q.1.10 \n");
                Console.WriteLine("---004---     Coca Cola           Q.17.00 \n");
                Console.WriteLine("---005---     Libra de Café       Q.50.00 \n");
                do
                {
                inicio:
                    Console.WriteLine("Ingrese el código de producto: ");
                    codigoProducto = Console.ReadLine();
                    Console.WriteLine("Ingrese la cantidad de dicho producto: ");
                    bool convertido1 = int.TryParse(Console.ReadLine(), out int cantidadProductos);
                    if (cantidadProductos < 0 && convertido1 == false)
                    {
                        Console.WriteLine("//////La cantidad de producto debe ser mayor a cero//////");
                        Console.ReadKey();
                        goto inicio;
                    }else
                    switch (codigoProducto)
                    {
                        case "001":
                            precioProducto = (float)10.8;
                            cant001 += cantidadProductos;
                            break;
                        case "002":
                            precioProducto = (float)3.8;
                            cant002 += cantidadProductos;
                            break;
                        case "003":
                            precioProducto = (float)1.1;
                            cant003 += cantidadProductos;
                            break;
                        case "004":
                            precioProducto = 17;
                            cant004 += cantidadProductos;
                            break;
                        case "005":
                            precioProducto = 50;
                            cant005 += cantidadProductos;
                            break;
                        default:
                            Console.WriteLine("//////Código Desconocido//////");
                            Console.ReadKey();
                            goto inicio;
                    }
                    subtotal = cantidadProductos * precioProducto ;
                    total += subtotal;
                valid:
                    Console.WriteLine("¿Desea ingresar otro producto (S/N)?");
                    opcion = Console.ReadLine().ToUpper();
                    if (opcion != "S" && opcion != "N")
                    {
                        Console.WriteLine("//////Respuesta no válida//////");
                        Console.ReadKey();
                        goto valid;
                    }
                    else
                    {
                        cantidadProducto += cantidadProductos;
                    }
                    
                } while (opcion != "N");
                Console.ReadKey();
                cantidadFacturas++;
                Console.WriteLine($"#Factura {cantidadFacturas}\n TIENDA-MAS-URL");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine($"NIT: 7896451328964");
                Console.WriteLine("Fecha y Hora: " + DateTime.Now);
                Console.WriteLine($"Cliente: {NomFac}");
                Console.WriteLine($"NIT del cliente: {NIT}");
                Console.WriteLine($"Correo electrónico del cliente: {correo}");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine($"Libra de Azúcar {cant001} x  Q.10.80  {Math.Round((cant001*10.8),2)}");
                Console.WriteLine($"Libra de Arroz  {cant002} x  Q.3.80  {Math.Round((cant002 * 3.8),2)}");
                Console.WriteLine($"Galleta GAMA    {cant003} x  Q.1.10  {Math.Round((cant003 * 1.1),2)}");
                Console.WriteLine($"Coca Cola       {cant004} x  Q.17.00  {Math.Round((float)(cant004 * 17),2)}");
                Console.WriteLine($"Libra de Café   {cant005} x  Q.50.00  {Math.Round((float)(cant005 * 50),2)}");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine($"Subtotal: ${Math.Round(total, 2)}");
                Console.WriteLine($"IVA:  12%");
                Console.WriteLine($"Total: ${Math.Round((total*1.12),2)}");
                Console.ReadKey();

                MetododePago(total, puntos);
            }
            public int MetododePago(float total, int puntos)
            {
            metreinicio:
                try
                {
                    Console.WriteLine("1. Tarjeta de debito o crédito");
                    Console.WriteLine("2. Efectivo");
                    Console.Write("Ingrese modo de pago (Tarjeta/Efectivo): ");
                    string modoPago = Console.ReadLine();
                    if (modoPago.ToLower() != "1" && modoPago.ToLower() != "2")
                    {
                        throw new Exception();
                    }
                    if (modoPago.ToLower() == "1")
                    {
                        if (total <= 50 && total >= 10)
                        {
                            puntos = (int)(total / 10);
                            cantidadPuntos += puntos;
                            Console.WriteLine($" Usted a adquirido {puntos} puntos");
                        }
                        else if (total <= 100 && total > 50)
                        {
                            puntos = (int)(total / 10) * 2;
                            cantidadPuntos += puntos;
                            Console.WriteLine($" Usted a adquirido {puntos} puntos");
                        }
                        else if (total > 100)
                        {
                            puntos = (int)(total / 10) * 3;
                            cantidadPuntos += puntos;
                            Console.WriteLine($" Usted a adquirido {puntos} puntos");
                        }
                    }
                    Console.WriteLine("¡Gracias por comprar en tienda más!");
                    Console.ReadKey();
                }
                catch (Exception)
                {
                    Console.WriteLine("//////Método inválido vuelva a ingresar//////");
                    goto metreinicio;
                }
                return cantidadPuntos;
            }
            public void ReporteDeFacturacion()
            {
                Console.Clear();
                Nombre();
                Console.WriteLine($"1. Total de facturas realizadas >> \n{cantidadFacturas} Facturas generadas");
                Console.WriteLine($"2. Total de productos vendidos >> \n{cantidadProducto} Productos vendidos");
                Console.WriteLine($"3. Total de puntos generados >> \n{cantidadPuntos} Puntos generados");
            }
        }
        static void Main()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Tiendamas tienda = new Tiendamas();
            string nombrecliente;
            string nitcliente;
            string correocliente;
            inicio:
            Console.Clear();
            Nombre();
            Console.WriteLine("1. FACTURACIÓN ");
            Console.WriteLine("2. REPORTES DE FACTURACIÓN");
            Console.WriteLine("3. Salir del programa");
            Console.WriteLine("Elige una de las opciones usando su número");
            bool convertido = int.TryParse(Console.ReadLine(), out int nop);
            if (convertido == true && (nop <= 3 && nop >= 1))
            {
                
                if (nop == 1)
                {
                    Console.Clear();
                    Nombre();
                    Console.WriteLine("Ingrese nombre del cliente");
                    nombrecliente = Console.ReadLine();
                    Console.WriteLine("Ingrese el NIT del cliente");
                    nitcliente = Console.ReadLine();
                    Console.WriteLine("Ingrese el correo del cliente");
                    correocliente = Console.ReadLine();
                    tienda.Facturacion(nombrecliente,nitcliente,correocliente);
                    Console.ReadKey();
                    goto inicio;
                }
                else if (nop == 2)
                {
                    tienda.ReporteDeFacturacion();
                    Console.ReadKey();
                    goto inicio;
                }
                else if (nop == 3)
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opción no válida");
                Console.ReadKey();
                goto inicio;
            }

        }
    }
}
