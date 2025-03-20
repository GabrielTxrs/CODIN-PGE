<template>
  <form class="buscar-advogado">

    <h1>Tela de Advogado</h1>
    <fieldset>
      <legend>Buscar Advogado:</legend>

      <label for="idAdvogado">Id</label>
      <input type="text" id="idAdvogado" v-model="filtro.idAdvogado" maxlength="100" />

      <label for="NomePessoaFisica">Nome </label>
      <input type="text" id="NomePessoaFisica" v-model="filtro.nomePessoaFisica" maxlength="100" />

      <button class="btn btn-success m-1" @click.prevent="buscarAdvogado">Buscar</button>
    </fieldset>

    <table class="table table-bordered table-striped">
      <thead class="thead-dark">
        <tr>
          <th>ID</th>
          <th>Oab</th>
          <th>Procurador</th>
          <th>Nome</th>
          <th>Nome Social</th>
          <th>CPF</th>
          <th>Celular</th>
          <th>Telefone</th>
          <th>Email</th>
          <th>Data de Nascimento</th>
          <th>Alterar</th>
          <th>Excluir</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="advogado in advogados" :key="advogado.idAdvogado">
          <td>{{ advogado.idAdvogado }}</td>
          <td>{{ advogado.oab }}</td>
          <td>{{ advogado.isProcurador }}</td>
          <td>{{ advogado.nomePessoaFisica }}</td>
          <td>{{ advogado.nomeSocial }}</td>
          <td>{{ advogado.cpf }}</td>
          <td>{{ advogado.celular }}</td>
          <td>{{ advogado.telefone }}</td>
          <td>{{ advogado.email }}</td>
          <td>{{ advogado.dataNascimento.substring(0, 10) }}</td>
          <td>
            <RouterLink class="btn btn-warning"
              :to="{ name: 'alterar-advogado', params: { idAdvogado: advogado.idAdvogado } }">Alterar</RouterLink>
          </td>
          <td><button class="btn btn-danger" @click="excluirAdvogado(advogado.idAdvogado)">Excluir</button></td>
        </tr>
      </tbody>
    </table>

  </form>
  <RouterLink class="btn btn-primary m-5" to="/cadastro-advogado">Cadastrar Advogado</RouterLink>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import axios from 'axios';

const filtro = ref({
  idAdvogado: '',
  nomePessoaFisica: ''
});

let advogados = ref([
  {
    idAdvogado: 1,
    oab: '12345',
    isProcurador: 'Sim',
    nomePessoaFisica: 'João Silva',
    nomeSocial: '',
    cpf: '123.456.789-00',
    celular: '(11) 91234-5678',
    telefone: '(11) 3456-7890',
    email: 'joao.silva@email.com',
    dataNascimento: '1990-01-01'
  }
]);

async function buscarAdvogado() {
  try {
    let id = '';
    let nome = '';
    const params = new URLSearchParams();
    if (filtro.value.idAdvogado != undefined && filtro.value.idAdvogado != '') {
      id = filtro.value.idAdvogado;
      params.append('id', id);
    }
    if (filtro.value.nomePessoaFisica != undefined && filtro.value.nomePessoaFisica != '') {
      nome = filtro.value.nomePessoaFisica;
      params.append('nome', nome);
    }

    axios.get('https://localhost:7251/get-advogado-filtro', {
      params: params
    }).then((resposta) => {
      advogados.value = resposta.data
    });
  } catch (error) {
    console.error('Erro ao buscar advogados:', error);
  }
}

function excluirAdvogado(idAdvogado) {
  if (idAdvogado != undefined && idAdvogado != '') {
    axios.delete(`https://localhost:7251/remover-advogado/${idAdvogado}`)
      .then(() => {
        console.log(`Advogado com ID ${idAdvogado} excluído com sucesso.`);
        // Remove o advogado da tabela
        advogados.value = advogados.value.filter(advogado => advogado.idAdvogado !== idAdvogado);
      })
      .catch(error => {
        console.error(`Erro ao excluir advogado com ID ${idAdvogado}:`, error);
      });
  }
  buscarAdvogado();
}
onMounted(() => {
  buscarAdvogado();
});
</script>

<style scoped>
.buscar-advogado {
  display: flex;
  flex-direction: column;
  gap: 1rem;
  margin: 3rem;
}

.buscar-advogado label {
  font-weight: bold;
  margin: 0.5rem;
}

.buscar-advogado input {
  padding: 0.5rem;
  font-size: 1rem;
  font-size: 1rem;
}
</style>