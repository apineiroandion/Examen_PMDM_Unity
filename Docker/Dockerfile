# Usa una imagen base de Python
FROM python:3.9-slim

# Establece el directorio de trabajo en el contenedor
WORKDIR /app

# Copia el archivo Main.py al directorio de trabajo
COPY Main.py .

# Instala Flask
RUN pip install flask

# Exponer el puerto 8000
EXPOSE 8000

# Comando para ejecutar el script cuando se levante el contenedor
CMD ["python", "Main.py"]