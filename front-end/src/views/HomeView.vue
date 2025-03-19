<template>
  <form @submit.prevent="handleSubmit" class="login-form">
    <div class="row">
      <div class="col-lg-4 md-4 sm-8">
        <fieldset>
          <legend>Dados básicos:</legend>
          <label for="nmPessoaFisica">Nome Completo*</label>
          <input type="text" id="nmPessoaFisica" v-model="form.NM_PESSOA_FISICA" maxlength="100" required />
          
          <label for="nmSocial">Nome Social</label>
          <input type="text" id="nmSocial" v-model="form.NM_SOCIAL" maxlength="100" />
          
          <label for="nrCpf">CPF*</label>
          <input type="text" id="nrCpf" v-model="form.NR_CPF" maxlength="11" 
          @input="filterNumeric('NR_CPF')" required />

          <label>Data de Nascimento*</label>
          <VueDatePicker v-model="form.DT_NASCIMENTO" :enableTimePicker="false" placeholder="dd/mm/yyyy" teleport-center required />
        </fieldset>
    </div>
    
    <div class="col-lg-4 md-4 sm-8">
      <fieldset>
        <legend>Contato:</legend>
        <label for="nrCelular">Celular*</label>
        <input type="text" id="nrCelular" v-model="form.NR_CELULAR" maxlength="14" 
        @input="filterNumeric('NR_CELULAR')" required/>

        <label for="nrTelefone">Telefone</label>
        <input type="text" id="nrTelefone" v-model="form.NR_TELEFONE" maxlength="14"
        @input="filterNumeric('NR_TELEFONE')" />
        
        <label for="email">Email*</label>
        <input type="email" id="email" v-model="form.EMAIL" maxlength="60" required />
        
      </fieldset>
      <button type="submit">Login</button>
    </div>
  </div>

  </form>
</template>

<script>
import VueDatePicker from '@vuepic/vue-datepicker';
import '@vuepic/vue-datepicker/dist/main.css'

export default {
  components: { VueDatePicker },
  data() {
    return {
      form: {
        NM_PESSOA_FISICA: '',
        NM_SOCIAL: '',
        NR_CPF: '',
        NR_CELULAR: '',
        NR_TELEFONE: '',
        EMAIL: '',
        DT_NASCIMENTO: null,
      },
    };
  },
  methods: {
    handleSubmit() {
      console.log('Form submitted:', this.form);
    },
    filterNumeric(field) {
      this.form[field] = this.form[field].replace(/\D/g, '');
    },
  },
};
</script>

<style scoped>
.login-form {
  display: flex;
  flex-direction: column;
  gap: 1rem;
  margin: 3rem;
}

.login-form label {
  font-weight: bold;
}

.login-form input {
  padding: 0.5rem;
  font-size: 1rem;
  width: 100%;
}

button {
  margin-top: 1.3rem;
  padding: 0.7rem;
  font-size: 1rem;
  background-color: #007bff;
  color: white;
  border: none;
  cursor: pointer;
}

button:hover {
  background-color: #0056b3;
}
</style>