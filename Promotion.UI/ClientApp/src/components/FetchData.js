import React, { Component } from 'react';
import { connect } from 'react-redux'
import { getUserAction } from '../redux/actions/userActions'

export class FetchData extends Component {
    static displayName = FetchData.name;

    componentDidMount() {
        this.props.getUserAction();
    }

    render() {
        console.log(this.props)
        const { users } = this.props
        return (
            <div>
                <h1>Weather forecast</h1>
                <p>This component demonstrates fetching data from the server using Redux.</p>
                {users && users.map((post, i) => <div key={i}>
                    {post.data.first_Name}--{post.data.last_Name}
                    <img alt="avatar" src={post.data.avatar} />
                </div>)}
            </div>
        );
    }
}

//what is passed to the component via props
const mapStateToProps = (state) => {
    return {
        users: state.users
    };
}

export default connect(mapStateToProps, { getUserAction })(FetchData);
