import { createRouter, createWebHistory } from 'vue-router'
import Cliente from '@/views/cliente/Cliente.vue'
import Home from '../views/Home.vue'
import CadastroCliente from '@/views/cliente/CadastroCliente.vue'
import Advogado from '@/views/advogado/Advogado.vue'
import CadastroAdvogado from '@/views/advogado/CadastroAdvogado.vue'
import AlterarCliente from '@/views/cliente/AlterarCliente.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
    },
    {
      path: '/processos',
      name: 'processos',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/Processos.vue'),
    },
    {
      path: '/cliente',
      name: 'cliente',
      component: Cliente,
    },
    {
      path: '/cadastro-cliente',
      component: CadastroCliente,
    },
    {
      path: '/alterar-cliente/:idCliente', // New route with dynamic parameter
      name: 'alterar-cliente',
      component: AlterarCliente,
      props: true, // Pass route params as props to the component
    },
    {
      path: '/advogado',
      name: 'advogado',
      component: Advogado,
    },
    {
      path: '/cadastro-advogado',
      component: CadastroAdvogado,
    },
  ],
})

export default router
