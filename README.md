# RtM - Portfolio Website

A modern, interactive portfolio website built with Blazor WebAssembly and .NET 9, featuring a particle.js background animation, dark/light theme toggle, and smooth scrolling navigation.

![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet)
![Blazor](https://img.shields.io/badge/Blazor-WebAssembly-512BD4?logo=blazor)
![TailwindCSS](https://img.shields.io/badge/TailwindCSS-3.x-06B6D4?logo=tailwindcss)

## Features

- **Interactive Particle Background**: Dynamic particle.js animation on the hero section
- **Dark/Light Theme**: Persistent theme preference using browser localStorage
- **Smooth Scrolling**: Navigate between sections with smooth scroll animations
- **Responsive Design**: Mobile-first design with Tailwind CSS
- **Blazor WebAssembly**: Fast, client-side rendering with C# and .NET 9
- **Interactive Server Components**: Hybrid rendering mode support

## Tech Stack

- **.NET 9** - Latest .NET framework
- **Blazor WebAssembly** - Client-side web UI framework
- **C# 13.0** - Modern C# features
- **Tailwind CSS** - Utility-first CSS framework
- **JavaScript Interop** - For particle.js and theme management
- **Blazor.Heroicons** - Icon library

## Project Structure

```
RtM/
??? RtM/                          # Server project
?   ??? Components/
?   ?   ??? Layout/
?   ?   ?   ??? MainLayout.razor  # Main layout with hero section
?   ?   ?   ??? NavMenu.razor     # Navigation menu
?   ?   ?   ??? Footer.razor      # Footer component
?   ?   ??? Pages/
?   ?   ?   ??? Home.razor        # Home page with skills section
?   ?   ??? App.razor             # Root component
?   ??? wwwroot/
?   ?   ??? javascript/
?   ?   ?   ??? cookies.js        # Theme localStorage management
?   ?   ?   ??? scrollHelper.js   # Smooth scrolling utilities
?   ?   ?   ??? particles.js      # Particle.js library
?   ?   ?   ??? initParticles.js  # Particle initialization
?   ?   ??? images/               # Image assets
?   ?   ??? styles/               # Tailwind CSS styles
?   ??? Program.cs                # Application entry point
?
??? RtM.Client/                   # WebAssembly client project
    ??? RtM.Client.csproj
```

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- Node.js (optional, for Tailwind CSS compilation)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/rogerthemarquis/RtM.git
   cd RtM
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Build the solution**
   ```bash
   dotnet build
   ```

4. **Run the application**
   ```bash
   cd RtM
   dotnet run
   ```

5. **Open your browser**
   Navigate to `https://localhost:7124` (or the port shown in your console)

## Customization

### Theme Management

The theme is stored in browser localStorage and persists across sessions. The theme toggle functionality can be found in:
- `wwwroot/javascript/cookies.js` - localStorage functions
- `Components/Layout/MainLayout.razor.cs` - C# theme logic

### Particle Effects

Customize the particle background by modifying:
- `wwwroot/javascript/initParticles.js` - Particle configuration
- Adjust colors, density, speed, and other parameters

### Styling

The project uses Tailwind CSS for styling. To customize:
1. Modify Tailwind classes in `.razor` files
2. Update `styles/tailwind/` configuration if needed
3. Recompile Tailwind CSS (if using the Tailwind CLI)

## Dependencies

### Server Project (RtM)
- `Microsoft.AspNetCore.Components.WebAssembly.Server` v9.0.2
- `Blazor.Heroicons` v2.2.0

### Client Project (RtM.Client)
- `Microsoft.AspNetCore.Components.WebAssembly` v9.0.2

## Deployment

### Build for Production

```bash
dotnet publish -c Release
```

The published files will be in `RtM/bin/Release/net9.0/publish/`

### Hosting Options

- **Azure Static Web Apps**
- **GitHub Pages**
- **Netlify**
- **Vercel**
- **Any static file hosting service**

## Contributing

Contributions, issues, and feature requests are welcome!

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## Author

**Roger Marquis**
- GitHub: [@rogerthemarquis](https://github.com/rogerthemarquis)

## Acknowledgments

- [Blazor](https://blazor.net/) - Microsoft's web framework
- [Particle.js](https://particles.js.org/) - Particle animation library
- [Tailwind CSS](https://tailwindcss.com/) - CSS framework
- [Heroicons](https://heroicons.com/) - Icon library

---
