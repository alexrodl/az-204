# 🧪 Día 03 - Azure Storage (Parte 1 - Blob Storage)

## 🎯 Objetivos

- Entender qué es Azure Storage
- Conocer los tipos de almacenamiento disponibles
- Crear una Storage Account
- Trabajar con Blob Storage
- Subir y acceder a archivos

---

## 🧠 Conceptos clave

- Storage Account
- Blob Storage
- Containers
- Blobs
- Acceso público vs privado

---

## 🧩 Introducción

Azure Storage es un servicio altamente escalable que permite almacenar distintos tipos de datos.

Tipos principales:

- Blob Storage → archivos (imágenes, videos, documentos)
- Queue Storage → mensajes
- Table Storage → datos NoSQL
- File Storage → sistema de archivos

👉 En esta clase nos enfocamos en **Blob Storage**

---

## 🖥️ Demo (Portal)

Vamos a crear:

- Storage Account
- Container
- Subir un archivo (blob)

👉 Objetivo: entender cómo se almacenan y acceden los archivos en Azure

---

## 🧪 Laboratorio

Laboratorio:  
https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-storage/01-blob-storage-resources-dotnet.html

---

## 🧭 Enfoque de la clase

- Crear una Storage Account
- Crear un container
- Subir archivos
- Acceder a los blobs mediante URL

---

## ⚠️ Notas importantes

- El nombre de la Storage Account debe ser único globalmente
- Usar la misma región que otros recursos
- Tener en cuenta el nivel de acceso del container (public/private)

---

## 🔥 Conceptos importantes

### 🔹 Storage Account

Es el recurso principal que contiene todos los datos.

👉 Es como el “contenedor general” de almacenamiento

---

### 🔹 Container

Es una agrupación de blobs.

👉 Similar a una carpeta

---

### 🔹 Blob

Es el archivo en sí.

👉 Ejemplo:
- imagen
- PDF
- video

---

### 🔹 Acceso

- Private → solo acceso autenticado
- Public → accesible vía URL

👉 IMPORTANTE: esto tiene impacto en seguridad

---

## 🚀 Demo opcional

Acceder a un archivo público vía navegador usando su URL

👉 Esto ayuda a entender cómo funciona el acceso directo

---

## 🚀 Comandos útiles (opcional)

Listar cuentas de storage:

```bash
az storage account list --output table