using System.Text;

//----------------- BUENAS PRACTICAS ------------------

//CONVENCIONES DE NOMBRES

// Se recomienda utilizar PascalCase para los nombres de los namespaces, las clases, los métodos y las constantes
// Se recomienda utilizar camelCase para los nombres de las variables y parámetros
// Se recomienda utilizar nombres descriptivos y significativos para las variables y métodos
//Para el caso de las interfaces se recomienda utilizar la letra I al inicio del nombre de la interface y a continuacion el nombre de la interface en PascalCase

// -------------------------------

// PROPERTIES

// Los Setter y Getter de las propiedades deben ser publicos, a menos que se necesite restringir el acceso a la propiedad
// Se recomienda utilizar propiedades auto-implementadas para las propiedades que no requieren lógica adicional

// ES UNA MUY MALA PRACTICA UTILIZAR UN CAMPO PUBLICO
// Ejemplo de campo publico: public string Apellido;

//Ejemplo de Setter y Getter
/*
public class Persona
{
public string Nombre { get; set; } // Propiedad auto-implementada
public int Edad { get; set; } // Propiedad auto-implementada

// Propiedad con lógica adicional en el Setter
private string _apellido;
public string Apellido
{
    get { return _apellido; }
    set
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("El apellido no puede ser vacío");
        }
        _apellido = value;
    }
}
}
*/

// -------------------------------

// IMNUTABILIDAD DE LOS STRINGS
// Se recomienda utilizar la clase StringBuilder para concatenar cadenas de texto en lugar de utilizar el operador + ya que como los tipos string son inmutables, es decir que no pueden cambiar, cada vez que se realiza una concatenación con el operador + se crea un nuevo objeto de cadena en memoria, lo que puede afectar el rendimiento si se realizan muchas concatenaciones.
// La clase StringBuilder es más eficiente y evita la creación de múltiples objetos de cadena
//Ejemplo de inmutabilidad de los strings
String cadena = "Hola";
cadena += " Mundo";
cadena += "!"; // por cada concatenación,se crea un nuevo objeto de cadena en memoria,por lo que se vuelve a crear una y otra vez ralentizando el rendimiento

// -------------------------------

// COMPARACION DE CADENAS VACIAS
// Se recomienda utilizar string.IsNullOrEmpty() para verificar si una cadena es nula o está vacía
// En lugar de utilizar string.Length == 0 o string == ""
// Ejemplo de comparación de cadenas vacías
string cadenaVacia = "";
string cadenaNula = null;
bool esVacia = string.IsNullOrEmpty(cadenaVacia); // true
bool esNula = string.IsNullOrEmpty(cadenaNula); // true
// Se recomienda utilizar string.IsNullOrWhiteSpace() para verificar si una cadena es nula, está vacía o contiene solo espacios en blanco
// Ejemplo de comparación de cadenas vacías
string cadenaConEspacios = "   ";   
bool esVaciaConEspacios = string.IsNullOrWhiteSpace(cadenaConEspacios); // true
// De la misma manera se puede utilizar en un bloque if
if (string.IsNullOrEmpty(cadenaVacia))
{
    Console.WriteLine("La cadena está vacía o es nula");
}
else
{
    Console.WriteLine("La cadena no está vacía");
}
//Tambien se puede utilizar string.Empty
//Ejemplo
if (cadenaVacia == "") { } //Muy mala practica

if (cadenaVacia == string.Empty) { } // Buena practica

// -------------------------------

//OPERADORES LOGICOS
// Se recomienda utilizar el doble && y el doble || para las comparaciones lógicas
// ya que el operador & y el operador | realizan una evaluación de ambos lados de la expresión, en cambio, el operador && y el operador || realizan una evaluación corta, es decir que si el primer operando es falso, no evalúa el segundo operando

// -------------------------------

// FUNCIONALIDADES
// Al utilizar métodos, se recomienda utilizar una sola funcionalidad, es decir, no mezclar varias funcionalidades en un solo método, es preferible dividir el método en varios métodos más pequeños y específicos dado que esto mejora la legibilidad y el mantenimiento del código. Lo mismo sucede para el caso de las clases, se recomienda utilizar una sola funcionalidad por clase, es decir, no mezclar varias funcionalidades en una sola clase, es preferible dividir la clase en varias clases más pequeñas y específicas.


// --------------- TIP´S Y EJEMPLOS ----------------

// Ejemplo de declaración de variables nuleables (Permite valores nulos)
// El simbolo de interrogación (?) indica que la variable puede ser nula
int? a = null; //Siempre es una buena practica utilizar el tipo nuleable

// ----------------------------------------------------

// Ejemplo de concatenacion d etextos
// funciona en todos los escenarios de C#
string nombre = "Juan" + Environment.NewLine + "Perez";
Console.WriteLine(nombre);

// ----------------------------------------------------

// Ejemplo de interpolacion de cadenas
// La interpolacion de cadenas es una forma de construir cadenas de texto
// a partir de otras cadenas y variables, utilizando llaves {} para indicar
// donde se deben insertar los valores de las variables
string nombre2 = "Juan";
string apellido = "Perez";
string nombreCompleto = $"{nombre2} {apellido}";
Console.WriteLine(nombreCompleto);

// ----------------------------------------------------

// Ejemplo de uso de la clase StringBuilder
// La clase StringBuilder es una clase que permite construir cadenas de texto
// de forma eficiente, especialmente cuando se necesita concatenar muchas cadenas
// de texto. Se utiliza el método Append para agregar cadenas de texto al StringBuilder
StringBuilder sb = new StringBuilder();
sb.Append("Hola");
sb.Append(" ");
sb.Append("Mundo");
sb.Append(" ");
sb.Append("!");
sb.AppendLine(); // Agrega un salto de línea
sb.Append("Adios");
Console.WriteLine(sb.ToString());

//Otro ejemplo
StringBuilder cadena = new StringBuilder();
List<string> lista = new List<string>() { "Juan", "Pedro", "Maria" };
foreach (var item in lista)
{
    cadena.Append(item);
    cadena.Append(" ");
}
Console.WriteLine(cadena.ToString());

// ----------------------------------------------------

// Ejemplo de uso de la clase StringBuilder con interpolacion de cadenas    
sb.Clear();
sb.Append($"Hola {nombre2} {apellido}");
Console.WriteLine(sb.ToString());

// ----------------------------------------------------

//Agregar un valor por defecto si una variable numerica viene null
// En este caso, se utiliza el operador de coalescencia nula (??) para asignar un valor por defecto
int? numero = null;
int valorPorDefecto = 10;
int resultado = numero ?? valorPorDefecto; // Si numero es null, se asigna valorPorDefecto
Console.WriteLine(resultado); // Imprime 10

// ----------------------------------------------------

// Uso del ReadOnlySpan
// ReadOnlySpan es una estructura que permite trabajar con una parte de un arreglo
// o una cadena de texto sin necesidad de crear una copia de los datos
string texto = "Hola Mundo";
ReadOnlySpan<char> span = texto.AsSpan(0, 4); // Obtiene un ReadOnlySpan con los primeros 4 caracteres
Console.WriteLine(span.ToString()); // Imprime "Hola"

// ----------------------------------------------------

// Objetos anonimos
// Los objetos anonimos son una forma de crear objetos sin necesidad de definir una clase
// Se utilizan para almacenar datos temporales o para pasar datos entre metodos
// Los objetos anonimos se definen utilizando la palabra clave new y se especifican las propiedades
var objetoAnonimo = new { Nombre = "Juan", Edad = 25 };
Console.WriteLine($"Nombre: {objetoAnonimo.Nombre}, Edad: {objetoAnonimo.Edad}");

//otra forma de crear un objeto anonimo asignando los valores con variables variables
nombre = "Juan Perez";
int edad = 30;
var objetoAnonimo2 = new { NombreCompleto = nombre, Edad = edad };
Console.WriteLine($"Nombre: {objetoAnonimo2.NombreCompleto}, Edad: {objetoAnonimo2.Edad}");
//una vez creado el objeto anonimo, no se puede modificar
// objetoAnonimo2.NombreCompleto = "Pedro Perez"; // Esto generaria un error de compilacion ya que sus propiedades son de solo lectura


// ----------------------------------------------------

//Uso de parametros indeterminados para un metodo
// Los parametros indeterminados permiten pasar un numero variable de argumentos a un metodo
// Se utilizala palabra reservada params y a continuacion el tipo que recibirá y [] para indicar que el metodo puede recibir un numero variable de argumentos
// En este caso, el metodo Sumar recibe un numero variable de enteros y devuelve la suma de todos ellos
int Sumar(params int[] numeros)
{
    int suma = 0;
    foreach (var numero in numeros)
    {
        suma += numero;
    }
    return suma;
}
// Ejemplo de uso del metodo Sumar
int resultadoSuma = Sumar(1, 2, 3, 4, 5); // Se pueden pasar varios argumentos
Console.WriteLine($"La suma es: {resultadoSuma}"); // Imprime 15

resultadoSuma = Sumar(1, 2, 3, 4, 5, 6, 7, 8);
Console.WriteLine($"La segunda suma es: {resultadoSuma}"); // Imprime 36

// ----------------------------------------------------

//Comparar dos cadenas de diferente casing
// Se utiliza el metodo String.Equals para comparar dos cadenas de texto
// Se puede especificar el tipo de comparacion que se desea realizar
string cadena1 = "Hola";
string cadena2 = "hola";
bool sonIguales = string.Equals(cadena1, cadena2, StringComparison.OrdinalIgnoreCase); // Ignora el casing
Console.WriteLine($"Las cadenas son iguales: {sonIguales}"); // Imprime true


// ----------------------------------------------------

//Uso de una variable ReadOnly
// ReadOnly es una palabra clave que indica que una variable no puede ser modificada
// Una variable ReadOnly solo puede ser asignada en el constructor de la clase

MiClase objeto = new MiClase(10);
Console.WriteLine(objeto.valor); // Imprime 10
// objeto.valor = 20; // Esto generaria un error de compilacion, ya que valor es readonly

// Ejemplo de uso de la clase MiClase
public class MiClase
{
    public readonly int valor;
    public MiClase(int valor)
    {
        this.valor = valor; // Asignacion en el constructor
    }
}


