# 🧪 Día 02 - Azure Functions (Serverless)

## 🎯 Objetivos

- Entender qué es el modelo serverless
- Conocer Azure Functions
- Diferenciar Azure Functions vs App Service
- Crear y ejecutar una Function App
- Trabajar con triggers básicos

---

## 🧠 Conceptos clave

- Serverless
- Event-driven architecture
- Function App
- Triggers (HTTP, Timer)
- Consumption Plan

---

## 🧩 Introducción

Azure Functions es un servicio serverless que permite ejecutar código sin gestionar infraestructura.

👉 A diferencia de App Service:
- No está siempre corriendo
- Se ejecuta en respuesta a eventos
- Se paga por ejecución

---

## ⚖️ Comparación

| App Service | Azure Functions |
|------------|----------------|
| Siempre activo | Se ejecuta por eventos |
| Costo continuo | Pago por ejecución |
| Ideal para APIs/web apps | Ideal para procesos/event-driven |

---

## 🖥️ Demo (Portal)

Vamos a crear:

- Function App
- HTTP Trigger Function

👉 Objetivo: entender cómo funciona el modelo serverless en Azure

---

## 🧪 Laboratorio

Laboratorio:  
https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-functions/01-functions-create-vscode-http.html

---

## 🧭 Enfoque de la clase

- Crear una Function App
- Ejecutar una función HTTP
- Entender cómo se dispara una Function
- Diferenciar este modelo del App Service

---

## ⚠️ Notas importantes

- La Function App debe tener un nombre único
- Verificar región y resource group
- Asegurarse de estar logueado:

```powershell
az login
```