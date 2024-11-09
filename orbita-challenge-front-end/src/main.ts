import { registerPlugins } from '@/plugins'

// Tailwind Css
import "./styles/style.css"

// Components
import App from './App.vue'

// Composables
import { createApp } from 'vue'

const app = createApp(App)

registerPlugins(app)

app.mount('#app')
