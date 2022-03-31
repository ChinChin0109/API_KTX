<template>
<div class="auth-wrapper">
   <div class="auth-inner">
      <div class="container">
        <div class="row">
          <div class="col">
              1 of 3
            </div>
            <div class="col">
              2 of 3
            </div>
            <div class="col">
              3 of 3
            </div>
          </div>
        <div class="row">
          <div class="col chi">
            <form @submit.prevent="handleSubmit">

                  <div class = "input-group mb-3">
                      <span class="input-group-text">Employee ID</span>
                      <input type="text" class="form-control" required>
                  </div>
                  <div class = "input-group mb-3">
                      <span class="input-group-text">Employee Name</span>
                      <input type="text" class="form-control" required>
                  </div>
                  <div class="input-group mb-3">
                      <span class="input-group-text">Department</span>
                      <select class="form-select" v-model ="department">
                      <option selected>{{department}}</option>
                      <option v-for="(dep,index) in departments" :key="index">
                      {{dep.departmentName}}</option>
                      </select>
                  </div>
                  <div class = "input-group mb-3">
                      <span class="input-group-text">Date Of Join</span>
                      <input type="date" class="form-control">
                  </div>
                  <button class="btn btn-block btn-change">Update</button>

              </form>
          </div>
          <div class="col">
            2 of 2
          </div>
        </div>
        
      </div>
  </div>
</div>
</template>

<script>


const Token = localStorage.getItem('token');
import AxiosAuth from '@/utils/axios.utils';

export default {
  name: "UpdateDep",
  data() {
    return {
      dep:{},
      departmentId: 0,
      departmentName: "",
    };
  },
  created() {
    let uri = `https://localhost:44382/api/department/${this.$route.params.id}`;
    AxiosAuth.instance().get(uri).then((response) => {
        this.dep = response.data;
    });
  },
  methods: {
    handleSubmit() {
        var that = this;
       // console.log(this.departmentId);
          AxiosAuth.instance().put("department",
          {
            departmentId: this.dep.departmentId,
            departmentName:this.dep.departmentName
          },
          {
            headers: {
                'Authorization': `Bearer ${Token}`,
                'Accept': '*/*',
                'Content-Type': 'application/json; charset=utf-8'
              }
          })
          .then(
              (response)=>{
                  console.log(response.data);
                  alert("Update successfully");
                  that.$router.push("/department");
              },
              function () {
                alert("Update failed");
              }
          );
  
    },
  },
};
</script>

<style>

     .chi{
        color: #FFFFFF;
        background-color: rosybrown !important;
    } 
</style>

