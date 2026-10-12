# Bitácora — Integration & AI Lab

## 2026-08-19
- Qué hice: creé el repo integration-ai-lab, la estructura inicial
  (fase-01-fundamentos, BITACORA.md) y escribí el README con el
  propósito del laboratorio y la métrica de éxito.
- Tiempo: 30 min
- Racha actual: 1 día

## 2026-08-19 (sesión 3)
- Qué hice: instalé Docker Desktop. Encontré un problema de
  virtualización no detectada — la causa era que WSL no estaba
  instalado en Windows. Corrí "wsl --install", reinicié, y después
  Docker Desktop arrancó bien. Confirmé con "docker run hello-world"
  y funcionó correctamente.
- Aprendizaje extra: Docker Desktop en Windows depende de WSL2 como
  backend para correr contenedores Linux.
- Tiempo: XX min (más de lo esperado por el troubleshooting de WSL)
- Racha actual: 1 día

## 2026-08-19 (sesión 4)
- Qué hice: corrí un contenedor interactivo de Ubuntu (docker run -it
  ubuntu bash), lo explore por dentro, salí, y aprendí a listarlo
  (docker ps -a) y borrarlo (docker rm).
- Aprendizaje extra: un contenedor "vive" mientras el proceso principal
  corre; al salir queda detenido pero no desaparece hasta que lo borro.
- Tiempo: XX min
- Racha actual: 1 día

## 2026-08-31 (sesión 5)
- Qué hice: levanté un contenedor de RabbitMQ con docker run -d,
  mapeando los puertos 5672 y 15672. Accedí al panel web de
  administración en localhost:15672. Después lo detuve con docker stop.
- Aprendizaje extra: -p mapea un puerto del contenedor a mi máquina;
  -d lo corre en background sin ocupar la terminal.
- Tiempo: XX min
- Racha actual: día 2


## 2026-09-07 (sesión 6 — inicio fase 02)
- Qué hice: creé un proyecto ASP.NET Core minimo (dotnet new webapi)
  dentro de fase-02-api-rest/. Lo corrí y confirmé que Swagger UI
  se genera automáticamente en /swagger.
- Tiempo: XX min
- Racha actual: día 2

## 2026-09-01 (sesión 7 — inicio fase 02)
- Qué hice: creé proyecto ASP.NET Core mínimo (dotnet new webapi) con
  .NET 10, dentro de fase-02-api-rest/. Descubrí que .NET 10 ya no
  incluye Swagger UI por defecto, solo genera el JSON de OpenAPI en
  /openapi/v1.json. Agregué Scalar.AspNetCore para tener interfaz
  visual, mapeada en Program.cs con app.MapScalarApiReference().
  Confirmé que funciona en http://localhost:5121/scalar/v1.
- Aprendizaje extra: el "contrato" de una API (OpenAPI) y su "vidriera"
  visual (Scalar/Swagger UI) son dos cosas separadas, no una sola.
- Tiempo: XX min
- Racha actual: día 2 (sesión 7)

## 2026-09-02 (sesión 8)
- Qué hice: agregué mi primer endpoint propio (GET /integrations/status)
  usando Minimal API, con .WithName y .WithTags. Confirmé que aparece
  documentado automáticamente en Scalar, lo probé desde ahí, y después
  borré el endpoint de ejemplo (weatherforecast).
- Aprendizaje extra: en .NET 10 con Minimal APIs, .WithTags agrupa
  endpoints en la documentación visual sin necesidad de Controllers.
- Tiempo: XX min
- Racha actual: día 3

## 2026-09-07 (sesión 9 — inicio fase 03)
- Qué hice: levanté n8n en un contenedor Docker (docker run -d,
  puerto 5678), creé mi cuenta local, y accedí al editor visual
  de workflows por primera vez.
- Tiempo: XX min
- Racha actual: día 3

## 2026-09-11 (sesión 10)
- Qué hice: creé mi primer workflow en n8n (Manual Trigger + HTTP
  Request) que llama a mi propia API (/integrations/status). Usé
  host.docker.internal en vez de localhost porque n8n corre dentro
  de un contenedor Docker y necesita esa dirección especial para
  llegar a servicios en mi máquina Windows.
- Aprendizaje extra: un contenedor no ve "localhost" del host, hay
  que usar host.docker.internal (o redes Docker más adelante).
- Tiempo: XX min
- Racha actual: día 3

## 2026-10-05 (sesión 11 — inicio fase 04)
- Qué hice: levanté Kafka con docker-compose (un solo broker, sin
  Zookeeper), creé un topic, y mandé/recibí un mensaje usando los
  scripts de consola (producer/consumer).
- Aprendizaje extra: a diferencia de EMS, el mensaje queda en el
  topic aunque ya lo haya leído un consumidor — no se borra al leerse.
- Tiempo: XX min
- Racha actual: día 1 (nueva racha)


## 2026-10-12 (sesión 13)
- Qué hice: releí el topic con --from-beginning y confirmé que el
  mensaje viejo seguía ahí.
- Aprendizaje: los mensajes persisten en el topic; cada consumidor
  lleva su propio offset.
- Tiempo: XX min
- Racha actual: X días

## 2026-10-12 (sesión 14)
- Qué hice: agregué Confluent.Kafka a LabApi y registré un productor.
  El endpoint /integrations/status ahora publica un evento en el topic
  lab-events. Lo verifiqué con un consumidor de consola.
- Aprendizaje extra: la API publica el evento y no sabe quién lo lee
  (desacople productor/consumidor).
- Tiempo: XX min
- Racha actual: X días

## 2026-10-12 (sesión 15)
- Qué hice: creé un worker de .NET (LabConsumer) que consume el topic
  lab-events con Confluent.Kafka. Vi los eventos viejos al primer
  arranque y los nuevos en vivo desde LabApi.
- Aprendizaje extra: GroupId identifica al consumidor; Kafka recuerda
  hasta dónde leyó cada grupo (offset). Al reiniciar, sigue desde ahí.
- Tiempo: XX min
- Racha actual: X días