<template>
<div class="auth-wrapper">
        <div class="auth-inner">
<div class="container">
  <div class="row">
    <div class="col col_1">
        <div class="row row_2" >
                <form >
                <div class=" row form-group">
                    <div class="col">
                        <label>Mã tòa</label>
                        <select class="form-select col" v-model ="department">
                        <option selected>{{department}}</option>
                        <option v-for="(dep,index) in departments" :key="index">
                        {{dep.departmentName}}</option>
                        </select>
                    </div>
                    <div class="col">
                        <label>Tầng</label>
                        <select class="form-select col" v-model ="department">
                        <option selected>{{department}}</option>
                        <option v-for="(dep,index) in departments" :key="index">
                        {{dep.departmentName}}</option>
                        </select>
                    </div>
                    <div class="col">
                        <label>Tổng số giường</label>
                        <select class="form-select col" v-model ="tsogiuong">
                        <option selected>{{tsogiuong}}</option>
                        <option v-for="(num,index) in listNumber" :key="index">
                        {{num}}</option>
                        </select>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col">
                        <label>Tên phòng</label>
                        <input
                        type="text"
                        class="form-control"
                        v-model="tenphong"
                        required
                        placeholder="Tên phòng"
                        />
                    </div>
                    <div class="col">
                        <label>Tình trạng</label>
                        <input
                        type="text"
                        class="form-control"
                        v-model="tinhtrang"
                        required
                        placeholder="Tình trạng"
                        />
                    </div>
                </div>
                <button class="btn btn-block btn-change">Create</button>
                </form>
            </div>
    </div>
    <div class="col chi">
      
    </div>
  </div>
  <br>
  <div class="dropdown-divider"></div>
  <div class="row">
    <router-link to="/createdepartment" class="btn m-2 fload-end add">Thêm Phòng</router-link>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>
                            Mã phòng
                        </th>
                        <th>
                            Mã tòa
                        </th>
                        <th>
                            Tên phòng
                        </th>
                        <th>
                            Tầng
                        </th>
                        <th>
                            Tổng số giường
                        </th>
                        <th>
                            Tình trạng
                        </th>
                        <th >
                            Options
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(p, index) in displayedPhong" :key="index">
                        <td>{{p.maphong}}</td>
                        <td>{{p.matoa}}</td>
                        <td>{{p.tenphong}}</td>
                        <td>{{p.tang}}</td>
                        <td>{{p.tsogiuong}}</td>
                        <td>{{p.tinhtrang}}</td>
                        <td>
                             <router-link :to="{name: 'updatedepartment', params: { id: p.Maphong }}" class="btn edit" title="Sửa">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                                <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                                <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                                </svg>
                             </router-link>
                            <button type="button" @click ="deleteClick(p.Maphong)"
                            class="btn btn-light mr-1" title="Xóa">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
                                <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"/>
                                </svg>
                            </button>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="pagination-row">
                <button class="pagination-button" v-if="page != 1" @click="page--">&lt;&lt;</button>
                <span class="choose" v-for="(pageNumber,undex) in pages.slice(page-1, page+5)" :key="undex" >
                    <button class="pagination-button"
                        @click="page = pageNumber">
                        {{pageNumber}} 
                    </button>
                </span>
                <button class="pagination-button" @click="page++" v-if="page < pages.length">&gt;&gt;</button>
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
     data()
    {
        return{
            listNumber: [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15],
            phongs:[''],
            maphong:0,
            matoa:0,
            tenphong:"",
            tsogiuongphong:0,
            tang:0,
            tinhtrang:"",
            page: 1,
            perPage: 3,
            pages: [],
        }
    },
    methods:{
        refreshData()
        {
           // console.log(token);
           if(Token)
           {
             AxiosAuth.instance().get('phong/', {
              headers: {
                'Authorization': `Bearer ${Token}`,
                'Accept': '*/*',
                'Content-Type': 'application/json; charset=utf-8'
              }
            })
            .then((response) => {
                console.log(response);
                this.phongs = response.data;
            });
           }
            

        },
        deleteClick(id)
        {
            if(!confirm("Are you sure?"))
            {
                return;
            }

            AxiosAuth.instance().delete("phong/"+id)
            .then(
                (response) =>{
                    console.log(response.data);
                    this.refreshData();
                    alert("Delete successfully");
                }
            )
        },
        setPages() {
            let numberOfpages = Math.ceil(this.phongs.length / this.perPage);
            for(let index = 1; index <= numberOfpages; index++)
            {
                this.pages.push(index);
            }
        },
        paginate (phongs) {
            let page = this.page;
            let perPage = this.perPage;
            let from = (page * perPage) - perPage;
            let to = (page * perPage);
            return phongs.slice(from, to);
        }
    },
    // mounted:function()
    // {
    //     this.refreshData();
    // }
    computed: {
        displayedPhong() {
            return this.paginate(this.phongs);
        }
    },
    watch: {
        phongs() {
            this.setPages();
        }
    },
    created() {
        this.refreshData();
    },
    filters: {
        triWords(value) {
            return value.split(" ").splice(0,20).join(" ")+ '...';
        }
    }
}
</script>

<style>

     .chi{
        color: #FFFFFF;
        background-color: rosybrown !important;
    } 
    .row_2 {
        margin:0px 0px 0px 10px;
    }
    .col_1 {
        margin:0px 10px 0px 0px;
    }
    form-select {
        height: 50px;
    }
</style>

