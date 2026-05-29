# ⚙️ Azure Durable Functions

## 🎯 Objetivos

- Entender qué son Durable Functions
- Comprender cuándo usarlas
- Ver conceptos principales
- Entender cómo funciona una orquestación
- Prepararse para el ejercicio práctico

---

# 🧠 ¿Qué son Azure Durable Functions?

Azure Durable Functions es una extensión de Azure Functions que permite crear workflows con estado.

👉 Permite coordinar varias funciones entre sí.

---

# 💡 Idea principal

Con Azure Functions normales:

```text
evento
  ↓
Function
```

---

Con Durable Functions:

```text
evento
   ↓
Orchestrator
   ↓
varias funciones coordinadas
```

---

# 🎯 ¿Para qué sirven?

Cuando un proceso necesita:

- varios pasos
- mantener estado
- esperar respuestas
- reintentos
- ejecutar tareas en orden

---

# 💡 Ejemplo simple

Procesamiento de imagen:

```text
Upload imagen
   ↓
Validar
   ↓
Generar thumbnail
   ↓
Guardar metadata
```

---

# ⚠️ Con Function normal

Tendrías que manejar:

- orden
- errores
- reintentos
- estado

manualmente.

---

# ✅ Con Durable Functions

Azure maneja:

- estado
- progreso
- reintentos
- coordinación

automáticamente.

---

# 🔥 Conceptos principales

# 1️⃣ Orchestrator Function

Es la función principal.

👉 Coordina el workflow.

---

# 💡 Ejemplo

```text
Start
 ↓
Validate
 ↓
GenerateThumbnail
 ↓
SaveMetadata
```

---

# 2️⃣ Activity Functions

Son funciones individuales que hacen trabajo concreto.

---

# 💡 Ejemplos

```text
ValidateImage
GenerateThumbnail
SaveMetadata
```

---

# 3️⃣ Client / Starter

Es quien inicia el workflow.

Puede ser:

- HTTP request
- Queue Trigger (Service Bus y Quere Storage)
- Timer Trigger
- Event Grid 

---

# 💡 Ejemplo

```text
Queue message
   ↓
Starter Function
   ↓
Orchestrator
```

---

# 4️⃣ State Management

Durable Functions guarda automáticamente:

- progreso
- estado
- resultados

---

# 💡 Ejemplo

```text
Step 1 completado
Step 2 pendiente
```

Azure lo recuerda.

---

# 5️⃣ Retry

Puede reintentar automáticamente.

---

# 💡 Ejemplo

```text
Guardar archivo
```

falla.

Azure:

```text
Retry
```

---

# 6️⃣ Wait / Long-running workflows

Puede esperar:

- aprobación humana
- evento externo
- tiempo programado

---

# 💡 Ejemplo

```text
Enviar solicitud
↓
Esperar aprobación
↓
Continuar workflow
```

---

# 🔥 Cómo funciona internamente

```text
Trigger
   ↓
Starter Function
   ↓
Orchestrator
   ↓
Activity 1
Activity 2
Activity 3
```

---

# 📌 Muy importante

## Orchestrator

NO hace trabajo pesado.

👉 Solo coordina.

---

## Activity

Hace trabajo real.

---

# 💡 Regla simple

Orchestrator:

```text
qué hacer y en qué orden
```

Activity:

```text
hacer el trabajo
```

---

# 🎯 Patrones comunes

# 🔹 Function Chaining

Ejecutar pasos en orden.

```text
Paso 1
↓
Paso 2
↓
Paso 3
```

---

# 🔹 Fan-out / Fan-in

Ejecutar en paralelo.

```text
Generar thumbnails
 ├─ image1
 ├─ image2
 └─ image3
```

Luego:

```text
esperar todas
```

---

# 🔹 Async HTTP APIs

Iniciar proceso largo y consultar luego.

---

# 🔹 Human Interaction

Esperar aprobación humana.

---

# 💡 Ejemplos reales

## 📸 Procesar imágenes

```text
Validar
↓
Thumbnail
↓
Guardar metadata
```

---

## 🛒 Pedido e-commerce

```text
Validar stock
↓
Cobrar
↓
Enviar email
```

---

## ✅ Aprobación

```text
Solicitar aprobación
↓
Esperar
↓
Continuar
```

---

# ⚖️ Azure Function vs Durable Function

| Azure Function | Durable Function |
|---|---|
| tarea puntual | workflow |
| stateless | stateful |
| simple | coordinada |
| corta duración | procesos largos |

---

# 🎯 Cuándo usar Durable Functions

Usar cuando necesitás:

✅ varios pasos  
✅ mantener estado  
✅ retries  
✅ workflows largos  
✅ coordinación

---

# 🚫 No usar cuando

Solo necesitás:

```text
un trigger simple
```

---

# 📌 Beneficios

- menos código manual
- workflows claros
- estado automático
- retry automático
- serverless

---

# 💡 Resumen final

## Azure Functions

👉 ejecutar una tarea.

---

## Durable Functions

👉 coordinar varias tareas manteniendo estado.

---

# 🔥 Frase final

> Azure Functions ejecuta trabajo.  
> Durable Functions orquesta workflows completos.