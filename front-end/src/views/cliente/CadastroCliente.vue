<template>
    <form @submit.prevent="handleSubmit" class="cadastro-form">
        <h2>Cadastro de Cliente</h2>
        <div class="row">
            <div class="col-lg-4 md-4 sm-8">
                <fieldset>
                    <legend>Dados básicos:</legend>
                    <label for="nmPessoaFisica">Nome Completo*</label>
                    <input type="text" id="nmPessoaFisica" v-model="form.NM_PESSOA_FISICA" maxlength="100" required />

                    <label for="nmSocial">Nome Social</label>
                    <input type="text" id="nmSocial" v-model="form.NM_SOCIAL" maxlength="100" />

                    <label for="nrCpf">CPF*</label>
                    <input type="text" id="nrCpf" v-model="form.NR_CPF" maxlength="11" @input="filterNumeric('NR_CPF')"
                        required />

                    <label>Data de Nascimento*</label>
                    <VueDatePicker v-model="form.DT_NASCIMENTO" :enableTimePicker="false" placeholder="dd/mm/yyyy"
                        teleport-center required />
                </fieldset>
            </div>

            <div class="col-lg-4 md-4 sm-8">
                <fieldset>
                    <legend>Contato:</legend>
                    <label for="nrCelular">Celular*</label>
                    <input type="text" id="nrCelular" v-model="form.NR_CELULAR" maxlength="14"
                        @input="filterNumeric('NR_CELULAR')" required />

                    <label for="nrTelefone">Telefone</label>
                    <input type="text" id="nrTelefone" v-model="form.NR_TELEFONE" maxlength="14"
                        @input="filterNumeric('NR_TELEFONE')" />

                    <label for="email">Email*</label>
                    <input type="email" id="email" v-model="form.EMAIL" maxlength="60" required />

                </fieldset>
                <button type="submit">Cadastrar</button>
            </div>
        </div>
    </form>
</template>

<script setup>
    import VueDatePicker from '@vuepic/vue-datepicker';
    import '@vuepic/vue-datepicker/dist/main.css'
    import { ref } from 'vue';

    const form = ref({
                NM_PESSOA_FISICA: '',
                NM_SOCIAL: '',
                NR_CPF: '',
                NR_CELULAR: '',
                NR_TELEFONE: '',
                EMAIL: '',
                DT_NASCIMENTO: null,
            });
    
    function handleSubmit() {
        console.log('Form submitted:', form.value);
    }
    function filterNumeric(field) {
        form.value[field] = form.value[field].replace(/\D/g, '');
    }

</script>

<style scoped>
.cadastro-form {
    display: flex;
    flex-direction: column;
    gap: 1rem;
    margin: 3rem;
}

.cadastro-form label {
    font-weight: bold;
}

.cadastro-form input {
    padding: 0.5rem;
    font-size: 1rem;
    width: 100%;
}

button {
  margin-top: 1.35rem;
  padding: 7px;
  font-size: 1rem;
  color: white;
  border-color:#007bff;
  background-color: #007bff; 
  border-radius: 5px;
}

button:hover {
    background-color: #0056b3;
}
</style>