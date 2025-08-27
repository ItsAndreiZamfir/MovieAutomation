MovieAutomation (UI Testing)

### Features

- Automated browser tests using Selenium WebDriver.
- Step definitions and assertions written with SpecFlow/Reqnroll.
- Page Object Model for maintainable UI automation.
- Custom helpers for waiting, element interaction, and dropdown handling.

### Setup

- Requires Renqroll extension to be installed in Visual Studio.
- Requires Selenium WebDriver plugin (or another supported WebDriver) to be installed in the automation project
- The automation project targets .NET 8.
- Feature files define BDD scenarios for UI flows.

### Running Tests

- Use Visual Studio Test Explorer or the `dotnet test` CLI command.
- Ensure your WebDriver and browser versions are compatible.

### Useful Information

- **Cookie Consent Handling:**  
  The automation handles cookie banners and overlays to ensure reliable element interaction.
- **Synchronization:**  
  Custom wait helpers ensure the page and dynamic elements are fully loaded before actions/assertions.
- **ScenarioContext:**  
  Data can be shared between step definitions using SpecFlow's `ScenarioContext`.

---

