import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import CadastroView from '@/views/CadastroView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
    },
    {
      path: '/processos',
      name: 'processos',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/ProcessosView.vue'),
    },
    {
      path: '/cadastro-cliente',
      name: 'cadastro-cliente',
      component: CadastroView,
    },
    {
      path: '/cadastro-advogado',
      name: 'cadastro-advogado',
      component: CadastroView,
    }
  ],
})

export default router
