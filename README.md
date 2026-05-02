# 🚗 GreenDrive Smart Grid & Lifecycle

Projeto da **Lista XV – Sistemas Distribuídos e Mobile**.

---

## 📌 Objetivo

API REST em .NET para gerenciar o ciclo de vida de baterias de veículos elétricos, com telemetria, regras de segurança e reciclagem.

---

## 🛠️ Tecnologias

* .NET 10 (Web API)
* C#
* Entity Framework Core
* SQLite
* Swagger

---

## 🧠 Entidades

* 🔋 Bateria
* ⚡ EstacaoCarga
* 📡 RegistroTelemetria
* ♻️ OrdemReciclagem

---

## ⚙️ Regras de Negócio

* 🔥 Temperatura > 85°C → **Bloqueia (400 BadRequest)**
* ♻️ SoH > 60% → Não pode reciclar (Second Life)
* 💰 Estação Ultra-Rápida → + R$ 250 no custo
* 🚫 SoH ≤ 10% → Bateria inativa (não pode alterar)

---

## 🧠 Desafio

**GET /api/intelligence/carbon-footprint**

* Soma custo por cidade
* Simula delay de 3 segundos

### 💡 Solução

Uso de mensageria (RabbitMQ) e cache (Redis) para melhorar desempenho em sistemas distribuídos.

---

## 🧪 Testes

* ✔ Criação de bateria (SoH 15%)
* ✔ Criação de estação (Belo Horizonte)
* ✔ ❌ Erro com temperatura 90°C
* ✔ ♻️ Cálculo automático (+250)
* ✔ 🧠 Endpoint de inteligência

---

## ▶️ Executar

```bash
git clone <repo>
cd GreenDriveApi
dotnet run
```

Acesse: `/swagger`

---

## 📸 Evidências

Prints na pasta `/prints`.

---

## 👨‍💻 Autor

Bernardo Araújo