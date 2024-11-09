import { createRouter, createWebHistory } from 'vue-router'

import LayoutApp from '../pages/_layouts/app.vue'
import Students from '@/pages/app/student/students.vue'
import About from '@/pages/app/about.vue'

const routes = [
  {
    path: '/',
    component: LayoutApp,
    children: [
      {
        path: '/students',
        name: 'home',
        component: Students
      },
      {
        path: '/',
        name: 'About',
        component: About
      }
    ]
  }
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
})

export default router
