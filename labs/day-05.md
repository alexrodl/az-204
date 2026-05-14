# 🧪 Día 05 - Implementación de soluciones en contenedores

## 🎯 Objetivos

- Entender qué es un contenedor
- Explorar la estructura de un Dockerfile

- Trabajar con Azure Container Registry (ACR)
- Ejecutar imágenes usando ACR Tasks 

- Desplegar contenedores en Azure Container Instances 
- Desplegar contenedores en Azure Container Apps --> Kubernetes pero administrado
- AKS Azure Kubernetes Services --> 

---

# 🧠 Conceptos clave

- Containers
- Dockerfile
- Imágenes
- Azure Container Registry (ACR)
- Azure Container Instances (ACI)
- Azure Container Apps 

---

# 🧩 Introducción

Los contenedores permiten empaquetar:

- aplicación
- runtime
- dependencias
- configuración

👉 Garantizando que la aplicación funcione igual en cualquier entorno.

---

# ⚖️ Containers vs Virtual Machines

| Containers | Virtual Machines |
|------------|------------------|
| Más livianos | Más pesadas |
| Inicio rápido | Inicio más lento |
| Comparten kernel | SO completo |
| Ideales para microservicios | Infraestructura tradicional |

---

# 🐳 Exploración de un Dockerfile

## 💡 Ejemplo

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY . .

ENTRYPOINT ["dotnet", "MyApi.dll"]
```

---

## 🔍 Explicación

### 🔹 FROM
Define la imagen base.

---

### 🔹 WORKDIR
Directorio de trabajo dentro del container.

---

### 🔹 COPY
Copia archivos al container.

---

### 🔹 ENTRYPOINT
Comando que se ejecuta al iniciar el container.

---

# 📦 Azure Container Registry (ACR)

## 🧠 ¿Qué es?

Azure Container Registry es un registry privado para almacenar imágenes de containers.

👉 Similar a Docker Hub, pero dentro de Azure.

---

## 🎯 Casos de uso

- almacenar imágenes privadas
- integración con pipelines
- despliegues automáticos

---

# ⚙️ ACR Tasks

## 🧠 ¿Qué permiten?

Permiten construir imágenes automáticamente en Azure.

👉 Sin necesidad de Docker local.

---

## 💡 Caso típico

```text
Push a GitHub → Build automática → Imagen en ACR
```

---

# 🧪 Laboratorio 1

[AZ-204T00-A-AZH-CEP-M05A] Build and run a container image with Azure Container Registry Tasks

https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-container-services/01-container-image-acr-tasks.html

## Build and run a container image with Azure Container Registry Tasks

👉 Objetivo:
- construir imágenes automáticamente
- almacenar imágenes en ACR

---

# 🚀 Azure Container Instances (ACI)

## 🧠 ¿Qué es?

La forma más simple de ejecutar un container en Azure.

👉 Sin administrar servidores.

---

## 🎯 Casos de uso

- pruebas rápidas
- jobs temporales
- procesamiento puntual

---

## ✅ Ventajas

- rápido
- simple
- pago por uso

---

# 🧪 Laboratorio 2

[AZ-204T00-A-AZH-CEP-M05B] Deploy a container to Azure Container Instances using Azure CLI commands

https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-container-services/02-run-container-aci.html

## Deploy a container to Azure Container Instances using Azure CLI commands

👉 Objetivo:
- desplegar un container rápidamente
- ejecutarlo directamente desde Azure CLI

---

# 🌐 Azure Container Apps

## 🧠 ¿Qué es?

Servicio serverless para ejecutar containers modernos.

👉 Permite:
- escalado automático
- revisiones
- microservicios
- integración con eventos

---

## 🎯 Casos de uso

- APIs modernas
- microservicios
- aplicaciones escalables

---

## 🔥 Conceptos importantes

### 🔹 Scaling automático
Escala según demanda.

---

### 🔹 Revisions
Permite manejar distintas versiones de la app.

---

### 🔹 Event-driven
Puede reaccionar a eventos y mensajes.

---

# ⚖️ Comparación rápida

| Servicio | Uso principal |
|----------|---------------|
| ACI | Containers simples |
| Container Apps | Apps modernas escalables |
| AKS | Kubernetes completo |

---

# 🧪 Laboratorio 3


[AZ-204T00-A-AZH-CEP-M05C] Deploy a container to Azure Container Apps with the Azure CLI

https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-container-services/03-deploy-to-container-apps.html

## Deploy a container to Azure Container Apps with the Azure CLI

👉 Objetivo:
- desplegar aplicaciones modernas basadas en containers
- trabajar con escalado serverless  

---

# ⚠️ Notas importantes

- El nombre del registry debe ser único
- Las imágenes deben existir en ACR antes del despliegue
- Container Apps puede tardar algunos minutos en aprovisionar

---

# 📌 Resumen

- Los containers encapsulan aplicaciones y dependencias
- Dockerfile define cómo construir la imagen
- ACR almacena imágenes privadas
- ACI ejecuta containers simples rápidamente
- Container Apps permite aplicaciones modernas escalables

---
