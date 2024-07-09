namespace EjemploEntity.Utilitrios
{
    public class ControlError
    {
        public void LogErrorMetodos(string clase,string error, string metodo)
        {
			var ruta = string.Empty;
			var archivo = string.Empty;
			var mensaje = string.Empty;
			DateTime Fecha = DateTime.Now;
			try
			{
				ruta = "C:\\ProyectoIntegrador\\Log";
				archivo = $"Log_{Fecha.ToString("dd-MM-yyyy")}";

				if (!Directory.Exists(ruta))
				{
					Directory.CreateDirectory(ruta);
				}

				StreamWriter writ = new StreamWriter($"{ruta}\\{archivo}", true);
				writ.WriteLine($"Se presentó una novedad en la clase: {clase} en el método: {metodo}, con el siguiente error: {error}");
				writ.Close();

			}
			catch (Exception ex)
			{

				throw;
			}
        }
    }
}
