<template>
  <div class="wrapper">
      <div class="inner">
          <form @submit.prevent="handleSubmit">
          <h3>Sing up</h3>

          <div class="form-group">
            <label>First name</label>
            <input
              type="text"
              class="form-control"
              v-model="firstname"
              placeholder="First name"
            />
          </div>
          <div class="form-group">
            <label>Last name</label>
            <input
              type="text"
              class="form-control"
              v-model="lastname"
              placeholder="Last name"
            />
          </div>
          <div class="form-group">
            <label>Email</label>
            <input
              type="email"
              class="form-control"
              v-model="email"
              placeholder="Email"
            />
          </div>
          <div class="form-group">
            <label>Password</label>
            <input
              type="password"
              class="form-control"
              v-model="password"
              placeholder="Password"
            />
          </div>
          <div class="form-group">
            <label>Permission</label>
            <input
              type="text"
              class="form-control"
              v-model="permission"
              placeholder="Permission"
            />
          </div>
          <button class="btn btn-block btn-change">Register</button>
        </form>
      </div>
  </div>

</template>

<script>
import axios from "axios";

export default {
  name: "Register",
  data() {
    return {
      firstname: "",
      lastname: "",
      email: "",
      password: "",
      permission: "",
    };
  },
  methods: {
    handleSubmit() {
      var that = this;
      axios
        .post("user/register", {
          firstname: this.firstname,
          lastname: this.lastname,
          email: this.email,
          password: this.password,
          permission: this.permission,
        })
        .then(
          function (res) {
            console.log(res);
            that.$router.push("/login");
          },
          function (err) {
            alert(err);
          }
        );
    },
  },
};
</script>
