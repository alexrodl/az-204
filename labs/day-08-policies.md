# 🔄 Pipeline de Policies en Azure API Management

## 🧠 Introducción

En Azure API Management, las policies se ejecutan en distintas etapas del flujo de una request.

👉 Cada etapa permite:
- modificar requests
- aplicar seguridad
- transformar respuestas
- controlar tráfico

---

# 📌 Flujo general

```text
Cliente
   ↓
Frontend
   ↓
Inbound Processing
   ↓
Backend
   ↓
Outbound Processing
   ↓
Cliente
```

---

# 🌐 Frontend

## 🧠 ¿Qué es?

Define cómo la API se expone a los clientes.

👉 Es la “cara pública” de la API.

---

## 🎯 ¿Para qué sirve?

- definir rutas
- definir operaciones
- definir métodos HTTP
- exponer endpoints

---

## 💡 Ejemplo

```text
GET /products
POST /orders
```

---

## ⚠️ Importante

Frontend:
- NO procesa requests
- NO modifica responses

👉 Solo define cómo se presenta la API.

---

# 🔽 Inbound Processing

## 🧠 ¿Qué es?

Etapa que se ejecuta ANTES de enviar el request al backend.

---

## 🎯 ¿Para qué sirve?

Permite:

- autenticación
- validación JWT
- rate limiting
- transformación de headers
- validación requests
- reescritura URLs

---

## 💡 Ejemplo

### Rate limiting

```xml
<rate-limit calls="5" renewal-period="60" />
```

---

## 💡 Ejemplo

### Validación JWT

```xml
<validate-jwt ... />
```

---

## 🔥 Idea clave

Inbound controla y modifica el request antes del backend.

---

# ⚙️ Backend

## 🧠 ¿Qué es?

Define cómo APIM se comunica con el backend real.

---

## 🎯 ¿Para qué sirve?

- cambiar backend dinámicamente
- load balancing
- failover
- retry policies

---

## 💡 Ejemplo conceptual

```text
APIM
   ↓
Backend A
o
Backend B
```

---

## ⚠️ Importante

👉 En escenarios básicos suele usarse menos.

---

# 🔼 Outbound Processing

## 🧠 ¿Qué es?

Etapa que se ejecuta DESPUÉS de recibir respuesta del backend.

---

## 🎯 ¿Para qué sirve?

Permite:

- modificar responses
- agregar headers
- transformar JSON/XML
- ocultar información
- cachear respuestas

---

## 💡 Ejemplo

### Agregar header

```xml
<set-header name="X-Course">
    <value>AZ-204</value>
</set-header>
```

---

## 🔥 Idea clave

Outbound modifica la respuesta antes de enviarla al cliente.

---

# 📌 Flujo completo explicado

```text
Cliente
   ↓
Frontend
   ↓
Inbound Policies
   ↓
Backend API
   ↓
Outbound Policies
   ↓
Cliente
```

---

# 💡 Analogía simple

## Azure API Management como un aeropuerto

| Etapa | Analogía |
|------|-----------|
| Frontend | Mostrador |
| Inbound | Seguridad/control |
| Backend | Avión |
| Outbound | Entrega equipaje |

---

# 🔥 Policies más comunes

| Tipo | Uso típico |
|------|-------------|
| validate-jwt | autenticación |
| rate-limit | limitar requests |
| set-header | agregar/modificar headers |
| rewrite-uri | cambiar URLs |
| cache-lookup | caching |

---

# 📌 Resumen

| Etapa | Función |
|------|----------|
| Frontend | expone API |
| Inbound | procesa requests |
| Backend | llama backend |
| Outbound | procesa responses |

---

# 🔥 Concepto importante

👉 API Management puede modificar:
- requests
- responses
- seguridad
- tráfico

SIN modificar el backend.

---

# 🗣️ Preguntas para la clase

- ¿Qué policies creen que son más útiles?
- ¿Por qué aplicar rate limiting?
- ¿Qué ventajas tiene modificar requests sin cambiar el backend?
- ¿Qué etapa usarían para validar JWT?