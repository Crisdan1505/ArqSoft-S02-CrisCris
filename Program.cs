var repositorio = new Ahorcado.PalabrasEnMemoria();

Console.WriteLine("¿Qué juego quieres jugar?");
Console.WriteLine("  1 — Ahorcado");
Console.WriteLine("  2 — Viborita");
Console.Write("Opción: ");

var opcion = Console.ReadLine();

if (opcion == "2")
{
    var motor = new Ahorcado.MotorViborita();
    var ui = new Ahorcado.ConsolaUIViborita(motor);

    Console.CursorVisible = false;

    while (!motor.Ganado() && !motor.Perdido())
    {
        ui.MostrarTablero();

        var tecla = ui.LeerTecla();

        if (tecla == ConsoleKey.Q)
        {
            break;
        }

        if (tecla != ConsoleKey.NoName)
        {
            motor.CambiarDireccion(tecla);
        }

        motor.Avanzar();

        // Velocidad del juego
        Thread.Sleep(150);
    }

    ui.MostrarTablero();

    ui.MostrarMensaje(
        motor.Ganado()
            ? "\n¡Ganaste! Llegaste a 10 puntos."
            : "\nGame over."
    );
}
else
{
    // UI temporal para pedir categoría
    var uiTemporal = new Ahorcado.ConsolaUI(null);

    string categoria = uiTemporal.PedirCategoria();

    // Crear motor con categoría
    var motor = new Ahorcado.MotorAhorcado(
        repositorio,
        categoria
    );

    var ui = new Ahorcado.ConsolaUI(motor);

    Console.WriteLine("=== AHORCADO ===");

    while (!motor.Ganado() && !motor.Perdido())
    {
        ui.MostrarTablero();

        char letra = ui.PedirLetra();

        if (motor.LetraYaUsada(letra))
        {
            ui.MostrarMensaje("Ya usaste esa letra.");
            continue;
        }

        motor.RegistrarLetra(letra);
    }

    ui.MostrarTablero();

    if (motor.Ganado())
    {
        ui.MostrarMensaje(
            $"\n¡Ganaste! La palabra era: {motor.PalabraSecreta}"
        );
    }
    else
    {
        ui.MostrarMensaje(
            $"\nPerdiste. La palabra era: {motor.PalabraSecreta}"
        );
    }

    if (ui.PreguntarOtraVez())
    {
        var nuevoMotor = new Ahorcado.MotorAhorcado(
            repositorio,
            categoria
        );

        var nuevaUI = new Ahorcado.ConsolaUI(nuevoMotor);
    }
}