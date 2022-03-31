<template>
  <div class="wrapper">
      <div class="inner">
          <form @submit.prevent="handleSubmit">
          <h3 class="title-department">Create</h3>

          <div class="form-group">
            <label>Department Name</label>
            <input
              type="text"
              class="form-control"
              v-model="departmentName"
              required
              placeholder="Department Name"
            />
          </div>
          <button class="btn btn-block btn-change">Add</button>
        </form>
      </div>
  </div>

</template>

<script>

const Token = localStorage.getItem('token');
import AxiosAuth from '@/utils/axios.utils';

export default {
  name: "CreateDep",
  data() {
    return {
      departmentName: "",
    };
  },
  methods: {
    handleSubmit() {
        var that = this;

          AxiosAuth.instance().post("department",
          {departmentName:this.departmentName},
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
                  alert("Create successfully");
                      that.$router.push("/department");
        
              },
              function () {
                alert("Create failed");
              }
          );
  
    },
  },
};
</script>
<style>
  .title-department{
    padding-bottom: 20px;
    justify-content: center;
  }
  .wrapper {
    display: flex;
    justify-content: center;
    flex-direction: column;
    padding-top: 250px;
    text-align: left;
  }
 
  .inner{
    width: 500px;
    padding-top: 90px;
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
  .btn-change{
    background-color: rgb(125, 156, 163) !important;
  }
  .btn-change:hover{
    background-color: rosybrown !important;
  }
</style>
