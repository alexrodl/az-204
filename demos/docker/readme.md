# 🧪 Ejercicio - Crear y ejecutar un contenedor localmente con Docker

## 🎯 Objetivo

- Entender cómo funciona un contenedor
- Crear una imagen Docker localmente
- Ejecutar una aplicación .NET dentro de un container
- Comprender el flujo:
  Código → Imagen → Container

---

# 🧱 Paso 1 - Crear aplicación .NET

Crear una API simple:

```bash
dotnet new webapi -n ContainerDemo
```

Entrar al directorio:

```bash
cd ContainerDemo
```

---

# 📄 Paso 2 - Crear Dockerfile

Crear un archivo llamado:

```text
Dockerfile
```

👉 Sin extensión.

---

## 💡 Contenido del Dockerfile

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY . .

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ContainerDemo.dll"]
```

---

# 🔍 Explicación rápida

## 🔹 FROM
Define la imagen base.

---

## 🔹 WORKDIR
Define el directorio de trabajo dentro del container.

---

## 🔹 COPY
Copia archivos al container.

---

## 🔹 RUN
Ejecuta comandos durante el build.

---

## 🔹 ENTRYPOINT
Define qué aplicación se ejecutará al iniciar el container.

---

# 🏗️ Paso 3 - Construir imagen Docker

Ejecutar:

```bash
docker build -t containerdemo .
```

---

## 🔍 Explicación

- `docker build` → construye imagen
- `-t` → nombre/tag de la imagen
- `.` → contexto actual

---

# 📦 Paso 4 - Ver imágenes locales

```bash
docker images
```

👉 Verificar que exista:

```text
containerdemo
```

---

# 🚀 Paso 5 - Ejecutar el container

```bash
docker run -p 8080:8080 containerdemo
```

---

## 🔍 Explicación

- `docker run` → ejecuta container
- `-p 8080:8080` → mapea puertos

---

# 🌐 Paso 6 - Probar aplicación

Abrir navegador:

```text
http://localhost:8080
```

👉 La API debería estar funcionando dentro del container.

---

# 📌 Conceptos importantes

## 🧠 Imagen
Plantilla inmutable que contiene:
- aplicación
- runtime
- dependencias

---

## 🧠 Container
Instancia en ejecución de una imagen.

---

## 🧠 Dockerfile
Archivo con instrucciones para construir imágenes.

---

# 🔥 Flujo completo

```text
Código fuente
    ↓
Dockerfile
    ↓
Imagen Docker
    ↓
Container ejecutándose
```

---

# 🗣️ Preguntas para la clase

- ¿Qué ventaja tiene empaquetar la aplicación en un container?
- ¿Qué pasaría si ejecutamos este container en Azure?
- ¿Por qué el container funciona igual en cualquier entorno?

---

# 📌 Resumen

- Docker permite empaquetar aplicaciones
- Dockerfile define cómo construir la imagen
- La imagen puede ejecutarse localmente o en Azure
- Un container garantiza consistencia entre ambientes