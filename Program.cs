var repositorio = new Ahorcado.PalabrasEnMemoria();

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