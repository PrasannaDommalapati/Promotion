import React, { Component } from 'react'
import { connect } from 'react-redux'
import { createCourse } from '../redux/actions/courseActions'

class CoursePage extends Component {

    componentDidMount() {
        this.props.createCourse();
    }

    render() {
        const { courses } = this.props
        return (
            <div>
                <h2>List Courses</h2>
                {courses && courses.map((course,i) =><div key={i}>{course.email}</div>)}
            </div>
        )
    }
}
//what is passed to the component via props
const mapStateToProps = (state) => {
    return {
        courses: state.courses
    };
}

//what actions are passed to the component via props
const mapDispatchToProps = {
    createCourse
}


export default connect(mapStateToProps, mapDispatchToProps)(CoursePage);