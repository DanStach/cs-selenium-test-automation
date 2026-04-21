# SauceDemo Selenium Test Framework

A simple Selenium test automation framework built with **C#**, **.NET 8**, **xUnit**, and the **Page Object Model (POM)** pattern.
This project demonstrates a login test against https://www.saucedemo.com.

---

## 🚀 Prerequisites

Before getting started, make sure you have the following installed:

### 1. Install .NET 8 SDK

Download and install the .NET 8 SDK:

* https://dotnet.microsoft.com/en-us/download/dotnet/8.0

Verify installation:

```bash
dotnet --version
```

You should see something like:

```bash
8.x.x
```

---

### 2. Install a Browser

Make sure you have at least one of the following installed:

* Google Chrome
* Microsoft Edge

> Selenium Manager (built into Selenium 4) will automatically download the correct driver.

---

## 📥 Clone / Download the Repository

Clone the repo using Git:

```bash
git clone https://github.com/<your-repo>/cs-selenium-test-automation.git
cd cs-selenium-test-automation
```

Or download the ZIP and extract it.

---

## 📦 Restore Dependencies

Navigate to the test project folder (if needed):

```bash
cd SauceDemoTests
```

Restore NuGet packages:

```bash
dotnet restore
```

---

## 🏗️ Build the Project

```bash
dotnet build
```

---

## ▶️ Run the Tests

```bash
dotnet test
```

Expected behavior:

* Browser launches (unless running in headless mode)
* Navigates to SauceDemo
* Logs in using test credentials
* Verifies redirect to `inventory.html`
* Test passes ✅

---

## ⚙️ Configuration

Configuration is stored in:

```
appsettings.json
```

Example:

```json
{
  "TestSettings": {
    "BaseUrl": "https://www.saucedemo.com",
    "Username": "standard_user",
    "Password": "secret_sauce",
    "Browser": "chrome",
    "Headless": "false"
  }
}
```

### Options

| Setting  | Description            |
| -------- | ---------------------- |
| BaseUrl  | Target application URL |
| Username | Login username         |
| Password | Login password         |
| Browser  | chrome or edge         |
| Headless | true / false           |

---

## 🧪 Run Specific Tests

Run only smoke tests:

```bash
dotnet test --filter "Category=Smoke"
```

---

## 🧾 Test Output

* Console logs will be displayed during execution
* Screenshots are captured on failure (stored in `/Screenshots`)

---

## 🛠️ Troubleshooting

### Common Issues

**1. Browser does not launch**

* Ensure Chrome or Edge is installed

**2. Tests fail to start**

```bash
rm -rf bin obj
dotnet restore
```

**3. Dependency issues**

```bash
dotnet nuget locals all --clear
```

---

## 📁 Project Structure

```
SauceDemoTests/
├── Config/
├── Core/
├── Drivers/
├── Pages/
├── Tests/
├── Screenshots/
├── appsettings.json
└── SauceDemoTests.csproj
```

---

## 💡 Notes

* Built using **Page Object Model (POM)**
* Uses **Selenium Manager** (no driver binaries required)
* Designed for **scalability and CI/CD readiness**