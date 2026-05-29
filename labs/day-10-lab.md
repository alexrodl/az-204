# 🧪 Laboratorio - Azure Queue Storage + Durable Functions (.NET 8)

## 🎯 Objetivo

Crear un workflow usando:

- Azure Queue Storage
- Azure Durable Functions
- Azure Functions Core Tools
- .NET 8

Escenario:

👉 una web o proceso agrega un mensaje a una queue.

👉 una Durable Function procesa:

- validar imagen
- generar thumbnail
- guardar metadata

---

# 🏗️ Arquitectura

```text
Queue Storage
    ↓
Queue Trigger Starter
    ↓
Durable Orchestrator
    ├─ ValidateImage
    ├─ GenerateThumbnail
    └─ SaveMetadata
```

---

# 📋 Requisitos

Instalado:

- Visual Studio Code
- .NET 8
- Azure Functions Core Tools
- Azure Functions extension

Azure:

- Storage Account

---

# ☁️ Paso 1 - Crear Queue Storage

Ir a Azure Portal:

```text
Storage Account
→ Queues
→ Add Queue
```

Nombre:

```text
images
```

---

# 🏗️ Paso 2 - Crear proyecto

```bash
func init DurableImageProcessor --worker-runtime dotnet-isolated --target-framework net8
```

---

Entrar:

```bash
cd DurableImageProcessor
```

---

# 📦 Paso 3 - Instalar paquetes

```bash
dotnet add package Microsoft.Azure.Functions.Worker.Extensions.Storage.Queues
dotnet add package Microsoft.Azure.Functions.Worker.Extensions.DurableTask
```

---

# ⚙️ Paso 4 - local.settings.json

Configurar:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "<storage-connection-string>",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated"
  }
}
```

---

# 🚀 Paso 5 - Queue Trigger Starter

Crear archivo:

## StartImageWorkflow.cs

```csharp
using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask.Client;

namespace DurableImageProcessor;

public class StartImageWorkflow
{
    [Function("StartImageWorkflow")]
    public async Task Run(
        [QueueTrigger("images")] string blobName,
        [DurableClient] DurableTaskClient client)
    {
        await client.ScheduleNewOrchestrationInstanceAsync(
            "ImageWorkflow",
            blobName);

        Console.WriteLine(
            $"Workflow started for {blobName}");
    }
}
```

---

# 🔁 Paso 6 - Orchestrator

Crear archivo:

## ImageWorkflow.cs

```csharp
using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask;

namespace DurableImageProcessor;

public class ImageWorkflow
{
    [Function("ImageWorkflow")]
    public async Task Run(
        [OrchestrationTrigger]
        TaskOrchestrationContext context)
    {
        var blobName =
            context.GetInput<string>();

        await context.CallActivityAsync(
            "ValidateImage",
            blobName);

        await context.CallActivityAsync(
            "GenerateThumbnail",
            blobName);

        await context.CallActivityAsync(
            "SaveMetadata",
            blobName);
    }
}
```

---

# ⚙️ Paso 7 - Activity 1

Crear archivo:

## ValidateImage.cs

```csharp
using Microsoft.Azure.Functions.Worker;

namespace DurableImageProcessor;

public class ValidateImage
{
    [Function("ValidateImage")]
    public void Run(
        [ActivityTrigger] string blobName)
    {
        Console.WriteLine(
            $"Validating {blobName}");
    }
}
```

---

# ⚙️ Paso 8 - Activity 2

Crear archivo:

## GenerateThumbnail.cs

```csharp
using Microsoft.Azure.Functions.Worker;

namespace DurableImageProcessor;

public class GenerateThumbnail
{
    [Function("GenerateThumbnail")]
    public void Run(
        [ActivityTrigger] string blobName)
    {
        Console.WriteLine(
            $"Generating thumbnail for {blobName}");
    }
}
```

---

# ⚙️ Paso 9 - Activity 3

Crear archivo:

## SaveMetadata.cs

```csharp
using Microsoft.Azure.Functions.Worker;

namespace DurableImageProcessor;

public class SaveMetadata
{
    [Function("SaveMetadata")]
    public void Run(
        [ActivityTrigger] string blobName)
    {
        Console.WriteLine(
            $"Saving metadata for {blobName}");
    }
}
```

---

# ▶️ Paso 10 - Ejecutar local

```bash
func start
```

---

# 📨 Paso 11 - Enviar mensaje a queue

Desde Azure Portal:

```text
Storage Account
→ Queues
→ images
→ Add message
```

Mensaje:

```text
photo123.jpg
```

---

# 🔍 Resultado esperado

Consola:

```text
Workflow started for photo123.jpg

Validating photo123.jpg

Generating thumbnail for photo123.jpg

Saving metadata for photo123.jpg
```

---

# 💡 Qué explicar durante demo

## Queue Storage

Guarda el trabajo pendiente.

---

## Queue Trigger

Dispara workflow automáticamente.

---

## Durable Orchestrator

Coordina orden de pasos.

---

## Activity Functions

Ejecutan trabajo real.

---

## State

Azure mantiene progreso automáticamente.

---

# 🔥 Preguntas útiles para clase

## ¿Qué pasa si falla una activity?

Azure puede reintentar.

---

## ¿Dónde se guarda el estado?

En Storage Account.

---

## ¿Por qué usar Queue antes?

Desacopla:

- web app
- workflow

---

# 📌 Resumen

Queue Storage:

👉 guarda trabajo.

Durable Functions:

👉 define workflow.

Activities:

👉 hacen el trabajo.

---

# 🔥 Frase final

> Queue Storage recibe el trabajo.  
> Durable Functions coordina cómo ejecutarlo paso a paso.