# 🧪 Día 03 - Azure Storage

## 🎯 Objetivos

- Entender qué es una Storage Account
- Conocer los tipos de almacenamiento en Azure
- Comprender los tiers de almacenamiento
- Trabajar con Blob Storage
- Entender seguridad en Azure Storage
- Introducir ciclo de vida de datos

---

## 🧠 Conceptos clave

- Storage Account
- Blob Storage
- File Storage
- Queue Storage
- Table Storage
- Access tiers (Hot, Cool, Archive)
- Seguridad (keys, SAS, RBAC)

---

## 🧩 Introducción

Azure Storage es un servicio escalable que permite almacenar distintos tipos de datos en la nube.

Una Storage Account puede contener:

- Blob Storage → archivos (imágenes, videos, documentos)
- File Storage → sistema de archivos compartido
- Queue Storage → mensajería simple
- Table Storage → almacenamiento NoSQL

---

## 🏗️ Tipos de almacenamiento

### 🔹 Blob Storage
- Almacenamiento de objetos
- Ideal para archivos

### 🔹 File Storage
- Compartición de archivos tipo SMB

### 🔹 Queue Storage
- Mensajes entre aplicaciones

### 🔹 Table Storage
- Datos NoSQL estructurados

---

## ⚙️ Tiers de Storage

### 🔹 Standard
- Más económico
- Basado en HDD
- Uso general

### 🔹 Premium
- Mayor rendimiento
- Basado en SSD
- Baja latencia

👉 No todos los servicios están disponibles en todos los tiers

---

## 📦 Tipos de Blob Storage

- Block blobs → archivos comunes (imágenes, videos)
- Append blobs → logs
- Page blobs → discos (VMs)

---

## 🔥 Niveles de acceso (Access Tiers)

Aplican a Block Blobs:

- Hot → acceso frecuente
- Cool → acceso ocasional
- Archive → acceso muy poco frecuente

👉 Diferencias:
- costo de almacenamiento
- costo de acceso
- tiempo de recuperación (Archive)

---

## 🔐 Seguridad en Azure Storage

### 🔹 Access Keys
- Acceso completo a la cuenta

### 🔹 SAS (Shared Access Signature)
- Acceso limitado y temporal

### 🔹 RBAC (Azure AD)
- Control basado en roles

👉 Recomendación:
Usar SAS o RBAC en lugar de keys

---

## 🔄 Ciclo de vida de datos

Azure permite definir reglas automáticas:

- mover blobs de Hot → Cool → Archive
- eliminar datos antiguos

👉 Esto optimiza costos automáticamente

---

## 🖥️ Demo (Portal)

- Crear Storage Account
- Crear container
- Subir archivo
- Configurar acceso público
- Ver URL del blob

---

## 🧪 Laboratorio

Xtremelabs --> [AZ-204T00-A-AZH-CEP-M08] Create an Azure Function with Visual Studio Code

Laboratorios:  
https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-storage/01-blob-storage-resources-dotnet.html

👉 Seleccionar laboratorio de Blob Storage

---

## 🧭 Enfoque de la clase

- Entender la estructura de Storage
- Trabajar con blobs
- Comprender niveles de acceso
- Introducir seguridad básica

---

## ⚠️ Notas importantes

- El nombre de la Storage Account debe ser único globalmente
- El acceso público debe configurarse con cuidado
- Archive tiene tiempo de recuperación (no es inmediato)

---

## 🚀 Comandos útiles (opcional)

Listar storage accounts:

```bash
az storage account list --output table