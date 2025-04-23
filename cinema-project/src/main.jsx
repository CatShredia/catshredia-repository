import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./App.jsx";

createRoot(document.getElementById("root")).render(
  // строгий режим, нужен для разработчика
  // запускает так называемый стресс тест, для того, чтобы перепроверить код
  <StrictMode>
    <App />
  </StrictMode>
);
