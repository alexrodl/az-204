# 🧪 Día 09 - Arquitectura Event-Driven con Event Grid y Event Hub y Azure Service Bus

## 🎯 Objetivos

- Entender qué es arquitectura event-driven
- Comprender diferencias entre Event Grid y Event Hub
- Entender conceptos clave:
  - producers
  - consumers
  - topics
  - subscriptions
  - partitions
- Aprender cuándo usar cada servicio
- Realizar laboratorios prácticos

---

# 🧠 ¿Qué es arquitectura event-driven?

En una arquitectura event-driven los sistemas reaccionan a eventos.

👉 En lugar de:
- llamadas directas
- acoplamiento fuerte

los sistemas:
- generan eventos
- otros sistemas reaccionan a ellos

---

# 💡 Ejemplo simple

```text
Usuario sube archivo
    ↓
Se genera evento
    ↓
Otros sistemas reaccionan
```

---

# 🎯 Beneficios

- desacoplamiento
- escalabilidad
- procesamiento asíncrono
- integración entre sistemas

---

# 📦 Azure Event Grid

## 🧠 ¿Qué es?

Servicio orientado a distribución de eventos.

👉 Diseñado para:
- eventos discretos
- integración reactiva
- automatización

---

# 🎯 Idea principal

👉 “Algo ocurrió.”

---

# 💡 Ejemplo real

## Upload de imagen

```text
Usuario sube imagen
    ↓
Blob Storage genera evento
    ↓
Azure Function genera thumbnail
```

---

# 🔥 Conceptos importantes

## 🔹 Producer

Servicio que genera eventos.

👉 Ejemplo:
- Blob Storage
- App Service
- Custom Application

---

## 🔹 Event

Información de algo que ocurrió.

👉 Ejemplo:

```json
{
  "eventType": "BlobCreated",
  "subject": "/images/photo.jpg"
}
```

---

## 🔹 Topic

Canal donde se publican eventos.

👉 Puede ser:
- System Topic
- Custom Topic

---

## 🔹 Subscription

Define quién recibirá eventos.

👉 Permite conectar:
- Azure Functions
- Webhooks
- Logic Apps
- Event Hubs

---

## 🔹 Consumer

Sistema que consume el evento.

👉 Ejemplo:
- Azure Function
- Webhook
- API

---

# 💡 Arquitectura conceptual

```text
Producer
   ↓
Event Grid Topic
   ↓
Subscription
   ↓
Consumer
```

---

# 🔥 Características importantes

- push model
- near real-time
- serverless friendly
- integración sencilla

---

# 🎯 Casos ideales para Event Grid

- automatización
- integración entre servicios
- eventos de negocio
- serverless workflows

---

# 📌 Ejemplos típicos

| Evento | Acción |
|--------|---------|
| Blob creado | Procesar imagen |
| Usuario registrado | Enviar email |
| Pedido completado | Actualizar ERP |

---

# 🧪 Laboratorio Event Grid

## Objetivo

- Crear Event Grid Topic
- Crear Subscription
- Disparar eventos
- Consumir eventos

---

# 📦 Tipos de Topics en Azure Event Grid

## 🧠 Introducción

En Azure Event Grid existen distintos tipos de topics según el escenario y origen de los eventos.

👉 Los más importantes son:

- System Topics
- Custom Topics
- Domains
- Namespaces

---

# 🌐 System Topic

## 🧠 ¿Qué es?

Topic administrado automáticamente por Azure para eventos generados por servicios Azure.

---

# 🎯 ¿Para qué sirve?

Permite reaccionar a eventos de recursos Azure sin necesidad de crear topics manualmente.

---

# 💡 Ejemplos

- Blob Storage
- Resource Groups
- Key Vault
- App Configuration

---

# 💡 Ejemplo real

```text
Blob creado
    ↓
System Topic
    ↓
Azure Function
```

---

# ✅ Ventajas

- configuración simple
- integración automática
- ideal para automatización

---

# ⚠️ Importante

Azure administra:
- lifecycle
- publicación de eventos

---

# 🧩 Custom Topic

## 🧠 ¿Qué es?

Topic creado manualmente para publicar eventos personalizados desde aplicaciones.

---

# 🎯 ¿Para qué sirve?

Permite que aplicaciones propias publiquen eventos.

---

# 💡 Ejemplo real

```text
Aplicación e-commerce
    ↓
OrderCreated
    ↓
Custom Topic
    ↓
Consumers
```

---

# 💡 Casos típicos

- eventos de negocio
- integración entre aplicaciones
- microservicios

---

# ✅ Ventajas

- control total
- eventos personalizados
- desacoplamiento

---

# ⚠️ Importante

La aplicación debe:
- publicar eventos manualmente
- definir formato del evento

---

# 🌍 Domains

## 🧠 ¿Qué es?

Permite administrar múltiples topics relacionados bajo un mismo dominio.

---

# 🎯 ¿Para qué sirve?

Ideal para:
- multi-tenant
- grandes soluciones
- separación lógica de eventos

---

# 💡 Ejemplo real

```text
Empresa SaaS
    ↓
Cliente A Topic
Cliente B Topic
Cliente C Topic
```

Todos administrados bajo:
```text
Event Grid Domain
```

---

# ✅ Ventajas

- administración centralizada
- escalabilidad
- multi-tenant

---

# ⚠️ Importante

Cada tenant puede tener:
- su propio topic
- sus propias subscriptions

---

# 🚀 Namespaces

## 🧠 ¿Qué es?

Nueva capacidad de Event Grid orientada a escenarios modernos de mensajería y streaming de eventos.

---

# 🎯 ¿Para qué sirve?

Permite:
- alto throughput
- pull delivery
- retención de eventos
- consumidores múltiples

---

# 💡 Características importantes

- soporte push y pull
- retención eventos
- consumers independientes
- mayor flexibilidad

---

# 💡 Escenario típico

```text
Aplicaciones modernas
    ↓
Event Grid Namespace
    ↓
Múltiples consumidores
```

---

# ⚠️ Importante

Namespaces acercan Event Grid a escenarios más avanzados similares a:
- streaming
- event brokers modernos

---

# 📌 Comparación rápida

| Tipo | Uso principal |
|------|----------------|
| System Topic | eventos Azure automáticos |
| Custom Topic | eventos personalizados |
| Domain | multi-tenant y organización |
| Namespace | mensajería moderna/event streaming |

---

# 🔥 Resumen simple

## System Topic
👉 Azure genera eventos automáticamente.

---

## Custom Topic
👉 Tu aplicación publica eventos.

---

## Domain
👉 Agrupa múltiples topics.

---

## Namespace
👉 Escenarios modernos de mensajería y consumidores avanzados.

# 🌊 Azure Event Hub

## 🧠 ¿Qué es?

Servicio orientado a ingestión masiva de eventos y streaming.

👉 Diseñado para:
- telemetría
- IoT
- analytics
- streaming continuo

---

# 🎯 Idea principal

👉 “Están entrando millones de eventos constantemente.”

---

# 💡 Ejemplo real

## Telemetría IoT

```text
Miles de sensores
    ↓↓↓↓↓
Event Hub
    ↓
Analytics
```

---

# 🔥 Conceptos importantes

## 🔹 Producer

Aplicación o dispositivo que envía eventos.

👉 Ejemplo:
- sensores IoT
- aplicaciones
- logs

---

## 🔹 Event Hub

Canal de ingestión de eventos.

👉 Similar a:
- streaming pipeline

---

## 🔹 Partition

Permite distribuir eventos para:
- escalabilidad
- paralelismo

---

# 📦 Partitions en Azure Event Hub

## 🧠 ¿Qué son las partitions?

Las partitions son divisiones internas del stream de eventos en Event Hub.

👉 Permiten:
- distribuir eventos
- procesar en paralelo
- escalar throughput

---

# 💡 Idea principal

👉 Las partitions NO representan dispositivos.

👉 Representan capacidad de paralelismo.

---

# 🚗 Analogía simple

## Sin partitions

```text
Una sola carretera
```

---

## Con partitions

```text
Múltiples carriles
```

👉 Más throughput y procesamiento paralelo.

---

# 💡 Ejemplo

## Event Hub con 4 partitions

```text
Partition 0
Partition 1
Partition 2
Partition 3
```

---

# 🔑 Partition Key

## 🧠 ¿Qué es?

Valor utilizado para decidir en qué partition se almacenará un evento.

👉 Ejemplos:
- deviceId
- customerId
- orderId

---

# ⚠️ Importante

La Partition Key:

❌ NO crea nuevas partitions.

👉 Solo decide:
```text
a cuál partition existente va el evento
```

---

# 💡 Ejemplo

## 1 millón de devices

```text
device-1
device-2
device-3
...
device-1000000
```

👉 Todos se distribuyen entre pocas partitions.

Ejemplo:

```text
4 o 8 partitions
```

---

# 📌 Entonces...

## Tener más devices

❌ NO significa:
```text
más partitions
```

---

## Significa:

👉 Más eventos distribuidos entre las mismas partitions.

---

# 🔥 ¿Por qué usar Partition Key?

Permite que eventos relacionados:
- vayan misma partition
- mantengan orden

---

# 💡 Ejemplo

Todos los eventos de:

```text
device-123
```

👉 irán a la misma partition.

---

# ⚠️ Importante

El orden:
✅ se garantiza dentro de una partition

❌ NO entre partitions

---

# 🎯 ¿Cómo elegir cantidad de partitions?

La cantidad de partitions define:

- paralelismo máximo
- throughput máximo

---

# 📌 Regla práctica

👉 Elegir según:
- throughput esperado
- cantidad de consumers paralelos

---

# 💡 Ejemplo

## 4 partitions

👉 hasta:
```text
4 consumers paralelos
```

---

# ⚠️ Importante

En muchos tiers:
- partitions pueden aumentarse
- pero NO reducirse

---

# 📌 Resumen final

| Concepto | Significado |
|----------|-------------|
| Partition | división interna del stream |
| Más partitions | más paralelismo |
| Partition Key | agrupa eventos relacionados |
| Más devices | NO implica más partitions |
| Orden | solo dentro de una partition |

---

# 🔥 Frase importante

> “Las partitions no representan dispositivos.  
Representan capacidad de paralelismo.”

## 🔹 Consumer Group

Vista independiente del stream.

👉 Permite múltiples consumidores leyendo mismos eventos.

---

# 💡 Ejemplo

```text
App Analytics
App Monitoring
App ML
```

---

## 🔹 Consumer

Aplicación que procesa eventos.

👉 Ejemplo:
- Stream Analytics
- Spark
- Functions

---

# 💡 Arquitectura conceptual

```text
Producers
   ↓↓↓↓↓
Event Hub
   ↓
Partitions
   ↓
Consumer Groups
   ↓
Consumers
```

---

# 🔥 Características importantes

- altísimo throughput
- streaming continuo
- procesamiento masivo
- alta escalabilidad

---

# 🎯 Casos ideales para Event Hub

- IoT telemetry
- logs masivos
- analytics
- clickstream
- observabilidad

---

# 📌 Ejemplos típicos

| Escenario | Uso |
|-----------|-----|
| Sensores IoT | Telemetría |
| Logs aplicaciones | Streaming |
| Tracking usuarios | Analytics |

---

# 🧪 Laboratorio Event Hub

## Objetivo

- Crear Event Hub
- Enviar eventos
- Consumir stream
- Visualizar mensajes

---

# ⚖️ Comparación Event Grid vs Event Hub

| Característica | Event Grid | Event Hub |
|----------------|------------|------------|
| Tipo | eventos discretos | streaming masivo |
| Modelo | push | pull |
| Escala | moderada | muy alta |
| Escenario | automatización | analytics/IoT |
| Tiempo real | sí | sí |
| Throughput | medio | extremadamente alto |

---

# 🎯 Cuándo usar Event Grid

👉 Cuando:
- algo ocurre
- otros sistemas deben reaccionar

---

# 💡 Ejemplos

- archivo subido
- pedido completado
- usuario registrado

---

# 🎯 Cuándo usar Event Hub

👉 Cuando:
- llegan millones de eventos continuamente

---

# 💡 Ejemplos

- telemetría
- sensores
- logs
- tracking

---

# 🔥 Analogía simple

| Servicio | Analogía |
|----------|-----------|
| Event Grid | correo/notificación |
| Event Hub | tubería gigante de datos |

---

# 📌 Resumen final

## Event Grid

👉 Distribución de eventos.

👉 Ideal para:
- automatización
- integración reactiva

---

## Event Hub

👉 Ingestión masiva de streams.

👉 Ideal para:
- IoT
- analytics
- telemetría

---

# 🗣️ Preguntas para la clase

- ¿Qué diferencia hay entre eventos discretos y streams?
- ¿Por qué Event Hub necesita partitions?
- ¿Qué ventajas tiene desacoplar sistemas?
- ¿Qué escenarios reales conocen donde podrían usarse estos servicios?

---

# 🔥 Frase final importante

> “Si querés reaccionar a eventos → Event Grid.  
Si querés procesar millones de eventos → Event Hub.”

# Services Bus

## 🎯 Objetivos

- Entender mensajería en Azure
- Comprender diferencias entre:
  - Queue Storage
  - Service Bus
  - Event-driven architecture
- Entender conceptos:
  - queues
  - topics
  - subscriptions
  - producers
  - consumers
- Aprender cuándo usar cada servicio
- Comprender arquitecturas desacopladas

---

# 🧠 Introducción

En sistemas modernos muchas veces NO queremos comunicación directa entre aplicaciones.

👉 En lugar de:

```text
App A → App B
```

usamos mensajería:

```text
App A → Queue → App B
```

---

# 🎯 Beneficios

- desacoplamiento
- resiliencia
- procesamiento asíncrono
- escalabilidad

---

# ⚠️ Importante

Mensajería NO es exactamente lo mismo que event-driven architecture.

👉 Aunque están relacionados.

---

# 🔥 Diferencia conceptual importante

| Concepto | Objetivo |
|----------|-----------|
| Event-driven | reaccionar a eventos |
| Messaging | intercambiar mensajes confiables |

---

# 💡 Ejemplo Event-Driven

```text
Archivo subido
    ↓
Evento
    ↓
Múltiples sistemas reaccionan
```

👉 Event Grid.

---

# 💡 Ejemplo Messaging

```text
Pedido creado
    ↓
Mensaje en queue
    ↓
Sistema procesa pedido
```

👉 Queue / Service Bus.

---