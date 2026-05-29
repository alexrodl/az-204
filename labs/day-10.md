# 🧪 Día 10 -  Azure Queue Storage, Durable Functions y AppInsights

# 📦 Azure Queue Storage

## 🧠 ¿Qué es?

Servicio simple de colas dentro de Azure Storage.

👉 Permite almacenar mensajes para procesamiento asíncrono.

---

# 🎯 Idea principal

👉 “Guardar mensajes simples en una cola.”

---

# 💡 Arquitectura conceptual

```text
Producer
   ↓
Queue Storage
   ↓
Consumer
```

---

# 🔥 Conceptos importantes

## 🔹 Producer

Aplicación que envía mensajes.

---

## 🔹 Queue

Cola donde se almacenan mensajes.

---

## 🔹 Message

Información enviada.

👉 Generalmente simple.

---

## 🔹 Consumer

Aplicación que procesa mensajes.

---

# 💡 Ejemplo real

## Procesamiento de imágenes

```text
Usuario sube imagen
    ↓
Mensaje en Queue
    ↓
Worker procesa imagen
```

---

# 🎯 Casos ideales

- procesamiento simple
- background jobs
- tareas asíncronas
- bajo costo

---

# ✅ Ventajas

- muy simple
- económico
- escalable

---

# ⚠️ Limitaciones

- menos funcionalidades avanzadas
- no soporta topics/subscriptions
- no soporta ordering avanzado

---

# 📌 Características importantes

| Característica | Queue Storage |
|----------------|----------------|
| Simple | ✅ |
| Bajo costo | ✅ |
| Topics | ❌ |
| FIFO avanzado | ❌ |
| Transactions | ❌ |

---

# 🧪 Laboratorio Queue Storage

## Objetivo

- Crear Queue
- Enviar mensajes
- Leer mensajes
- Procesar mensajes

---

# 🚌 Azure Service Bus

## 🧠 ¿Qué es?

Servicio avanzado de mensajería enterprise.

👉 Diseñado para:
- alta confiabilidad
- workflows complejos
- integración enterprise

---

# 🎯 Idea principal

👉 “Mensajería avanzada y confiable.”

---

# 💡 Arquitectura conceptual

```text
Producer
   ↓
Service Bus
   ↓
Consumer
```

---

# 🔥 Componentes importantes

# 🔹 Queue

Mensajería punto a punto.

👉 Un consumer procesa el mensaje.

---

# 💡 Ejemplo

```text
Order Processing Queue
```

---

# 🔹 Topic

Permite publicar mensajes a múltiples consumidores.

👉 Similar a publish/subscribe.

---

# 🔹 Subscription

Canal independiente de consumo dentro de un topic.

---

# 💡 Ejemplo

```text
OrderCreated
    ↓
Topic
    ↓
Billing Subscription
Shipping Subscription
Analytics Subscription
```

---

# 🔹 Dead-letter Queue (DLQ)

Mensajes que fallaron procesamiento.

👉 Muy importante en sistemas enterprise.

---

# 🔹 Sessions

Permiten procesamiento ordenado de mensajes relacionados.

---

# 🔹 Duplicate Detection

Evita procesar mensajes duplicados.

---

# 💡 Ejemplo real

## E-commerce

```text
Pedido creado
    ↓
Service Bus Topic
    ↓
Facturación
Envíos
Analytics
```

---

# 🎯 Casos ideales

- sistemas enterprise
- workflows críticos
- integración compleja
- procesamiento confiable

---

# ✅ Ventajas

- alta confiabilidad
- ordering
- retries
- dead-letter queue
- publish/subscribe

---

# ⚠️ Más complejo y más costoso que Queue Storage

---

# 📌 Características importantes

| Característica | Service Bus |
|----------------|-------------|
| Topics | ✅ |
| Subscriptions | ✅ |
| Dead-letter queue | ✅ |
| Ordering | ✅ |
| Transactions | ✅ |
| Duplicate detection | ✅ |

---

# 🧪 Laboratorio Service Bus

## Objetivo

- Crear Queue
- Crear Topic
- Crear Subscription
- Enviar mensajes
- Consumir mensajes

---

# ⚖️ Queue Storage vs Service Bus

| Característica | Queue Storage | Service Bus |
|----------------|----------------|-------------|
| Complejidad | baja | alta |
| Costo | bajo | mayor |
| Enterprise features | ❌ | ✅ |
| Topics/Subs | ❌ | ✅ |
| Ordering | básico | avanzado |
| DLQ | ❌ | ✅ |

---

# 🎯 Cuándo usar Queue Storage

👉 Cuando:
- necesitás algo simple
- bajo costo
- procesamiento básico

---

# 💡 Ejemplos

- background jobs
- thumbnails
- tareas simples

---

# 🎯 Cuándo usar Service Bus

👉 Cuando:
- necesitás workflows enterprise
- múltiples consumidores
- confiabilidad avanzada

---

# 💡 Ejemplos

- e-commerce
- banking
- integración enterprise

---

# ⚠️ Diferencia importante con Event Grid/Event Hub

| Servicio | Objetivo |
|----------|-----------|
| Event Grid | reaccionar a eventos |
| Event Hub | streaming masivo |
| Queue Storage | mensajería simple |
| Service Bus | mensajería enterprise |

---

# 🔥 Arquitecturas típicas

# 🟢 Queue Storage

```text
Web App
   ↓
Queue
   ↓
Background Worker
```

---

# 🔵 Service Bus

```text
Order API
   ↓
Service Bus Topic
   ↓
Billing
Shipping
Analytics
```

---

# 📌 Conceptos importantes

## 🔹 Asynchronous Processing

Procesamiento desacoplado y diferido.

---

## 🔹 Decoupling

Las aplicaciones no dependen directamente unas de otras.

---

## 🔹 Retry

Reintento automático de procesamiento.

---

## 🔹 Dead-letter Queue

Mensajes problemáticos o fallidos.

---

# 📌 Resumen final

## Queue Storage

👉 Cola simple y económica.

👉 Ideal para:
- tareas básicas
- procesamiento simple

---

## Service Bus

👉 Mensajería enterprise avanzada.

👉 Ideal para:
- sistemas críticos
- workflows complejos
- múltiples consumidores

---

# 🗣️ Preguntas para la clase

- ¿Qué ventajas tiene desacoplar sistemas?
- ¿Por qué usar colas en lugar de llamadas directas?
- ¿Cuándo elegirían Queue Storage?
- ¿Qué problemas resuelve Service Bus?

---

# 📦 Ejemplos reales - Azure Queue Storage vs Service Bus

## 🟢 Azure Queue Storage

### 💡 Ejemplo real: Procesamiento de imágenes

Un usuario sube una imagen en una web.

```text
Web App
   ↓
Blob Storage
   ↓
Queue Storage
   ↓
Worker procesa thumbnail
```

---

## 📨 Mensaje en la cola

```json
{
  "blobName": "foto123.jpg"
}
```

---

## 🔍 ¿Por qué usar Queue Storage?

Porque es un escenario:

✅ simple  
✅ económico  
✅ asíncrono  
✅ tolera reintentos o duplicados

---

## 🎯 Ideal para

- thumbnails
- enviar emails simples
- exportar archivos
- tareas en background

---

## ⚠️ Importante

Si se procesa dos veces normalmente no pasa nada.

Ejemplo:

```text
Generar thumbnail nuevamente
```

👉 aceptable.

---

# 🔵 Azure Service Bus

### 💡 Ejemplo real: E-commerce al crear un pedido

Un cliente realiza una compra.

```text
Order API
    ↓
Service Bus Topic
    ↓
Billing
Shipping
Analytics
Email Notifications
```

---

## 📨 Mensaje

```json
{
  "orderId": 845,
  "customerId": 1001,
  "total": 150
}
```

---

## 🔍 ¿Por qué usar Service Bus?

Porque necesitás:

✅ alta confiabilidad  
✅ varios consumidores  
✅ retries automáticos  
✅ dead-letter queue  
✅ evitar duplicados

---

## 🎯 Ideal para

- pedidos
- pagos
- facturación
- integración enterprise

---

## ⚠️ Importante

En este caso duplicar el mensaje puede ser grave.

Ejemplo:

```text
Cobrar dos veces
```

❌ no aceptable

---

# 📊 Comparación rápida

| Escenario | Queue Storage | Service Bus |
|---|---:|---:|
| Thumbnail imágenes | ✅ | |
| Tareas simples | ✅ | |
| Bajo costo | ✅ | |
| Pedidos e-commerce | | ✅ |
| Varios sistemas | | ✅ |
| Retry avanzado | | ✅ |
| Dead-letter queue | | ✅ |

---

# 📌 Resumen

## Queue Storage

👉 tareas simples y económicas.

---

## Service Bus

👉 mensajería crítica y enterprise.

---

# 🔥 Frase final

> Queue Storage = “guardá esta tarea para después.”

> Service Bus = “asegurate que este mensaje importante llegue correctamente.”