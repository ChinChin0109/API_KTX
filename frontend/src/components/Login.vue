<template>
  <div class="wrapper">
      <div class="inner">
          <form @submit.prevent="handleSubmit">
          <h3>Login</h3>

          <div class="form-group">
            <label>Email</label>
            <input
              type="email"
              class="form-control"
              v-model="email"
              required
              placeholder="Email"
            />
          </div>
          <div class="form-group">
            <label>Password</label>
            <input
              type="password"
              class="form-control"
              v-model="password"
              required
              placeholder="Password"
            />
          </div>
          <button class="btn btn-block btn-change">Login</button>
        </form>
      </div>
  </div>

</template>

<script>
import axios from "axios";

export default {
  name: "Login",
  data() {
    return {
      email: "",
      password: "",
    };
  },
  methods: {
    handleSubmit() {
        var that = this;
      axios
        .post("user/login", {
          email: this.email,
          password: this.password,
        })
        .then(
          function (response) {
            console.log(response);
            localStorage.setItem("token", response.data.token);
            localStorage.setItem("UserId", response.data.userId);
            setTimeout(() => {
                that.$router.push("/department");
            }, 200);
          },
          function () {
            alert("login failed");
          }
        );

      // const a = localStorage.getItem('token');
      // console.log(a);

      
    },
  },
};
</script>
<style>
  .wrapper {
    display: flex;
    justify-content: center;
    flex-direction: column;
    padding-top: 200px;
    text-align: left;
  }
 
  .inner{
    width: 500px;
    margin: auto;
    background: #ffffff;
    box-shadow: 0px 14pz 80px rgba(34,35,58,0.2);
    padding: 40px 55px 45px 55px;
    border-radius: 15px;
    transition: all .3s;
  }
  .wrapper .form-control:focus{
    border-color: #167bff;
    box-shadow: none;
  }
</style>
