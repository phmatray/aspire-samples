/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./{Components,Pages}/**/*.{html,razor,cs,cshtml}"],
  darkMode: ["class", '[data-theme="dark"]'],
  theme: {
    extend: {},
  },
  plugins: [
    require("@tailwindcss/typography"),
    require("@tailwindcss/forms"),
    require("@tailwindcss/aspect-ratio"),
    require("daisyui")
  ],
  daisyui: {
    darkTheme: "dark", // name of one of the included themes for dark mode
    base: true, // applies background color and foreground color for root element by default
    styled: true, // include daisyUI colors and design decisions for all components
    utils: true, // adds responsive and modifier utility classes
    prefix: "", // prefix for daisyUI classnames (components, modifiers and responsive class names. Not colors)
    logs: true, // Shows info about daisyUI version and used config in the console when building your CSS
    themeRoot: ":root", // The element that receives theme color CSS variables
    themes: [ // false: only light + dark | true: all themes | array: specific themes like this ["light", "dark", "cupcake"]
      "light",
      "dark",
      "cupcake",
      "bumblebee",
      "emerald",
      "corporate",
      "synthwave",
      "retro",
      "cyberpunk",
      "valentine",
      "halloween",
      "garden",
      "forest",
      "aqua",
      "lofi",
      "pastel",
      "fantasy",
      "wireframe",
      "black",
      "luxury",
      "dracula",
      "cmyk",
      "autumn",
      "business",
      "acid",
      "lemonade",
      "night",
      "coffee",
      "winter",
      "dim",
      "nord",
      "sunset",
      {
        rsvzlight: {
          "primary": "#4b7128",
          "secondary": "#81992e",
          "accent": "#0031ff",
          "neutral": "#321c29",
          "base-100": "#fcfcfc",
          "info": "#55acee",
          "success": "#1bb761",
          "warning": "#f9b425",
          "error": "#f14d51",
        },
      },
    ],
  }
}

