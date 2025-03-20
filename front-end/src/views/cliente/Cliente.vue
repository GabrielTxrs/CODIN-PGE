<template>
    <form class="buscar-cliente">

        <h1>Tela de Cliente</h1>
        <fieldset>
            <legend>Buscar Cliente:</legend>

            <label for="idCliente">Id</label>
            <input type="text" id="idCliente" v-model="form.IdCliente" maxlength="100"/>

            <label for="NomePessoaFisica">Nome </label>
            <input type="text" id="NomePessoaFisica" v-model="form.NomePessoaFisica" maxlength="100" />

            <button id="buscar" @click="buscarCliente">Buscar</button>
        </fieldset>

        <table class="table table-bordered table-striped">
            <thead class="thead-dark">
                <tr>
                    <th>ID Cliente</th>
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
                <tr v-for="cliente in clientes" :key="cliente.idCliente">
                    <td>{{ cliente.idCliente }}</td>
                    <td>{{ cliente.nomePessoaFisica }}</td>
                    <td>{{ cliente.nomeSocial }}</td>
                    <td>{{ cliente.cpf }}</td>
                    <td>{{ cliente.celular }}</td>
                    <td>{{ cliente.telefone }}</td>
                    <td>{{ cliente.email }}</td>
                    <td>{{ cliente.dataNascimento }}</td>
                    <td><button @click="alterarCliente(cliente)">Alterar</button></td>
                    <td><button @click="excluirCliente(cliente.idCliente)">Excluir</button></td>
                </tr>
            </tbody>
        </table>

    </form>
    <RouterLink class="button" to="/cadastro-cliente">Cadastrar Cliente</RouterLink>
</template>

<script setup>
import { ref } from 'vue';
import axios from 'axios';

const form = ref({
    IdCliente: '',
    NomePessoaFisica: ''
});

const clientes = ref([
{
        idCliente: 1,
        nomePessoaFisica: 'João Silva',
        nomeSocial: '',
        cpf: '123.456.789-00',
        celular: '(11) 91234-5678',
        telefone: '(11) 3456-7890',
        email: 'joao.silva@email.com',
        dataNascimento: '1990-01-01'
    }
]);

async function buscarCliente() {
    console.log("buscando")
    try {
        const response = await axios.get('https://localhost:7251/get-cliente-filtro', {
            params: {
                id: form.value.IdCliente,
                nome: form.value.NomePessoaFisica
            }
        });
        clientes.value = response.data;
    } catch (error) {
        console.error('Erro ao buscar clientes:', error);
    }
}


function alterarCliente(cliente) {
    console.log('Alterar cliente:', cliente);
}

function excluirCliente(idCliente) {
    console.log("excluindo")
    axios.delete(`https://localhost:7251/remover-cliente/${idCliente}`)
        .then(() => {
            console.log(`Cliente com ID ${idCliente} excluído com sucesso.`);
            // Remove o cliente da tabela
            clientes.value = clientes.value.filter(cliente => cliente.idCliente !== idCliente);
        })
        .catch(error => {
            console.error(`Erro ao excluir cliente com ID ${idCliente}:`, error);
        });
}
</script>

<style scoped>
.buscar-cliente {
    display: flex;
    flex-direction: column;
    gap: 1rem;
    margin: 3rem;
}

.buscar-cliente label {
    font-weight: bold;
    margin: 0.5rem;
}

.buscar-cliente input {
    padding: 0.5rem;
    font-size: 1rem;
    font-size: 1rem;
}

#buscar {
  margin-left: 1.35rem;
  padding: 8px;
  font-size: 1rem;
  color: white;
  border-color: #007bff;
  background-color: #007bff; 
  border-radius: 5px;
}

.button {
    display: inline-block;
    margin: 3rem; 
    padding: 15px 30px;
    font-size: 18px;
    color: white;
    background-color: #007bff;
    border-radius: 5px;
}

.button:hover {
    background-color: #0056b3;
}
</style>