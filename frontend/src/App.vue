<template>
   <div id="app" class="container">
      <Nav :user="user" />
      <div>
            <router-view :user="user" />
      </div>
</div>
</template>

<script>
  import Nav from './components/Nav.vue';
  import AxiosAuth from './utils/axios.utils';

 const ID = localStorage.getItem('UserId');
  const Token = localStorage.getItem('token');

  export default {
      name: 'App',
      components: {
        Nav,
      },
      data() {
        return {
          user: null
        };
      },
      created() {
        if(Token)
        {
            let uri = `https://localhost:44382/api/user/${ID}`;
            AxiosAuth.instance().get(uri).then((response) => {
                this.user = response.data;
            });
        } else {
          return this.user= null;
        }
      }
  }
</script>

<style>

  @import url('https://fonts.googleapis.com/css?family=Fira+Sans:400,500,600,700,800');
  body{
    background: #6d8daa !important;
    min-height: 100vh;
    display: flex;
    font-weight: 400;
    font-family: 'Fira Sans', sans-serif;
  }
  h1,h2,h3,h4,h5,h6, label, span {
    font-weight: 500;
    font-family: 'Fira Sans', sans-serif;
  }

  body , html, #app, #root, .auth-wrapper {
    width: 100%;
    height: 100%;
  }

  #app{
    text-align: center;
  }

  .navbar-light{
    background-color: #ffffff;
    box-shadow: 0px 14px 80px rgba(34, 35, 58 0.2);
  }
  .home{
    color: rgb(22, 22, 22);
  }
</style>
