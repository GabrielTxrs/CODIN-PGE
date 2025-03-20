<template>
    <form class="buscar-cliente">

        <h1>Tela de Cliente</h1>
        <fieldset>
            <legend>Buscar Cliente:</legend>

            <label for="idCliente">Id</label>
            <input type="text" id="idCliente" v-model="filtro.idCliente" maxlength="100" />

            <label for="NomePessoaFisica">Nome </label>
            <input type="text" id="NomePessoaFisica" v-model="filtro.nomePessoaFisica" maxlength="100" />

            <button class="btn btn-success m-1" @click.prevent="buscarCliente">Buscar</button>
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
                    <td>{{ cliente.dataNascimento.substring(0,10) }}</td>
                    <td><RouterLink class="btn btn-warning" :to="{ name: 'alterar-cliente', params: { idCliente: cliente.idCliente } }">Alterar</RouterLink></td>
                    <td><button class="btn btn-danger" @click="excluirCliente(cliente.idCliente)">Excluir</button></td>
                </tr>
            </tbody>
        </table>

    </form>
    <RouterLink class="btn btn-primary m-5" to="/cadastro-cliente">Cadastrar Cliente</RouterLink>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import axios from 'axios';

const filtro = ref({
    idCliente: '',
    nomePessoaFisica: ''
});

let clientes = ref([
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
    try {
        let id = '';
        let nome = '';
        const params = new URLSearchParams();
        if (filtro.value.idCliente != undefined && filtro.value.idCliente != '') {
            id = filtro.value.idCliente;
            params.append('id', id);
        }
        if (filtro.value.nomePessoaFisica != undefined && filtro.value.nomePessoaFisica != '') {
            nome = filtro.value.nomePessoaFisica;
            params.append('nome', nome);
        }

        axios.get('https://localhost:7251/get-cliente-filtro', {
            params: params
        }).then((resposta) => {
            clientes.value = resposta.data
        });
    } catch (error) {
        console.error('Erro ao buscar clientes:', error);
    }
}

function excluirCliente(idCliente) {
    if (idCliente != undefined && idCliente != '') {
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
    buscarCliente();
}
onMounted(() => {
    buscarCliente();
});
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

</style>