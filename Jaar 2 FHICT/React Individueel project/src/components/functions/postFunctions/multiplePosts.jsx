import { Button } from "bootstrap";
import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import SearchForum from "../forumFunctions/SearchForum";
import ReadPost from "./posts";

export default function MultiplePosts(postIdsOnSearch) {
    let navigate = useNavigate();
    const [postIds, setPostIds] = useState([1,
        2, 3, 4, 5, 6, 7, 8, 9, 10])

    useEffect(() => {

        if (postIdsOnSearch.postIdsOnSearch && postIdsOnSearch.postIdsOnSearch.length) {
            setPostIds(postIdsOnSearch.postIdsOnSearch);
        }

    }, [postIdsOnSearch.postIdsOnSearch])

    return (
        <div>
            {
                postIds.map(
                    postId =>
                        <div key={postId}>
                            <div className="box" onClick={() => navigate(`/postWithComment/${postId}`)} >

                                <ReadPost postId={postId} />
                            </div>
                        </div>
                )
            }
        </div>
    )
}