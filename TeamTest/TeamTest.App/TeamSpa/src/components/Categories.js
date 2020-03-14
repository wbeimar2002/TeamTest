import axios from 'axios'
import React, {Component} from 'react';
import * as commonConstants from '../common/constants'
import {Table} from 'react-bootstrap';
class Categories extends Component{
    state = {
        cats: []
    }

    componentDidMount(){
        const uri = commonConstants.baseApiUrl+commonConstants.categoryResource;
        axios.get(uri)
            .then(res => {
            const cats = res.data;
            this.setState({ cats });
        }).catch(error => {
            throw error;
            });
    }

    render(){
        return(
            <div>
                <h1>Categories</h1>
                <br></br>
                <Table striped bordered hover >
                <thead>
                    <tr>
                    <th>Category Id</th>
                    <th>Category Name</th>
                    <th>Description</th>
                    </tr>
                </thead>
                <tbody>
                    { this.state.cats.map(cat => 
                        <tr key={cat.id}>
                            <td>{cat.id}</td>
                            <td>{cat.name}</td>
                            <td>{cat.description}</td>
                        </tr>)
                    }
                </tbody>
                </Table>
            </div>
        )
    }
}

export default Categories;