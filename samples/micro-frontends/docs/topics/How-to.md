# How to Install Tailwind CSS and DaisyUI

This guide will walk you through the process of installing and configuring Tailwind CSS and DaisyUI in your project. By the end of this tutorial, you will have successfully installed and set up both of these tools, allowing you to start building beautiful and responsive user interfaces.

## Before you start

To follow this tutorial, you will need:

- Node.js and npm installed on your computer
- A basic understanding of HTML, CSS, and JavaScript

## Install Tailwind CSS

Tailwind CSS is a popular utility-first CSS framework that allows you to quickly build custom user interfaces. Follow these steps to install Tailwind CSS in your project:

1. Install Tailwind CSS via npm, and create your `tailwind.config.js` file.

    ```bash
    npm i -D tailwindcss
    npx tailwindcss init
    ```

   This will create a `tailwind.config.js` file in your project's root directory.

2. Next, you will need to import the Tailwind CSS base, components, and utilities into your project. You can do this by adding the following code to your `index.css` file:

   ```sass
   @import 'tailwindcss/base';
   @import 'tailwindcss/components';
   @import 'tailwindcss/utilities';
   ```

## Install DaisyUI

DaisyUI is a popular component library for Tailwind CSS that provides pre-built UI components. Follow these steps to install DaisyUI in your project:

1. Install DaisyUI via npm.

    ```bash
    npm i -D daisyui@latest
    ```

2. Next, you will need to import the DaisyUI components into your project. You can do this by adding the following code to your `index.css` file:

    ```sass
    @import 'daisyui/dist/daisyui.css';
    ```

3. Finally, you will need to register DaisyUI with Tailwind CSS by adding the following code to your `tailwind.config.js` file:

    ```js
    module.exports = {
      theme: {
        // ...
      },
      plugins: [
        require('daisyui'),
      ],
    }
    ```

That's it! You have now successfully installed and configured Tailwind CSS and DaisyUI in your project. You can start building beautiful and responsive user interfaces using these tools.

## Troubleshooting

If you encounter any issues while following this tutorial, here are some tips to help you troubleshoot:

- Make sure you have the latest version of Node.js and npm installed on your computer.
- Check the error message and consult the documentation for Tailwind CSS and DaisyUI for more information.
- Make sure you have followed the steps in this tutorial exactly as written.

## Additional resources

- [Tailwind CSS documentation](https://tailwindcss.com/docs)
- [DaisyUI documentation](https://daisyui.com/)