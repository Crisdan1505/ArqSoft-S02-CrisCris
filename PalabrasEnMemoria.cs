namespace Ahorcado
{
    public class PalabrasEnMemoria : IRepositorioPalabras
    {
        private readonly Dictionary<string, List<string>> _categorias =
            new()
            {
                {
                    "Arquitectura",
                    new List<string>
                    {
                        "arquitectura",
                        "componente",
                        "descomposicion",
                        "dependencia",
                        "acoplamiento"
                    }
                },

                {
                    "POO",
                    new List<string>
                    {
                        "polimorfismo",
                        "encapsulamiento",
                        "herencia",
                        "abstraccion",
                        "clase"
                    }
                },

                {
                    ".NET",
                    new List<string>
                    {
                        "ensamblado",
                        "namespace",
                        "interfaz",
                        "delegado",
                        "middleware"
                    }
                }
            };

        public string ObtenerPalabraAleatoria(string categoria)
        {
            var random = new Random();

            var palabras = _categorias[categoria];

            return palabras[random.Next(palabras.Count)];
        }
    }
}