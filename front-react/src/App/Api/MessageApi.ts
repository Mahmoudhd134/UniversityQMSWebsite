﻿import {baseApi} from "./BaseApi";
import {AddMessageModel} from "../../Models/Message/AddMessageModel";
import {MessageForSendListModel} from "../../Models/Message/MessageForSendListModel";
import {MessageModel} from "../../Models/Message/MessageModel";
import {MessageForReceivedListModel} from "../../Models/Message/MessageForReceivedListModel";

const MessageApi = baseApi.injectEndpoints({
    endpoints: builder => ({
        getMessageById: builder.query<MessageModel, number>({
            query: arg => 'message/' + arg,
            providesTags: (result, error, arg) => [{type: 'message', id: arg}]
        }),
        getSendMessage: builder.query<MessageForSendListModel[], { pageIndex: number, pageSize: number }>({
            query: arg => ({
                url: 'message/getSend',
                params: {
                    'pageSize': arg.pageSize,
                    'pageIndex': arg.pageIndex
                }
            }),
            providesTags: (result = [], error, arg) => [
                'message',
                ...result.map(({id}) => ({type: 'message' as const, id}))
            ]
        }),
        getReceivedMessage: builder.query<MessageForReceivedListModel[], { pageIndex: number, pageSize: number }>({
            query: arg => ({
                url: 'message/getReceived',
                params: {
                    'pageSize': arg.pageSize,
                    'pageIndex': arg.pageIndex
                }
            }),
            providesTags: (result = [], error, arg) => [
                'message',
                ...result.map(({id}) => ({type: 'message' as const, id}))
            ]
        }),
        getIsHasUnReadMessages: builder.query<boolean, void>({
            query: () => 'message/checkUnReadMessage',
            providesTags: ['message']
        }),
        addMessage: builder.mutation<boolean, AddMessageModel>({
            query: arg => ({
                url: `message`,
                method: 'post',
                body: arg
            }),
            invalidatesTags: [{type: 'message'}]
        }),
        deleteMessage: builder.mutation<boolean, number>({
            query: arg => ({
                url: 'message/' + arg,
                method: 'delete'
            }),
            invalidatesTags: (result, error, arg) => [{type: 'message', id: arg}]
        })
    })
})

export const {
    useGetMessageByIdQuery,
    useGetSendMessageQuery,
    useGetReceivedMessageQuery,
    useGetIsHasUnReadMessagesQuery,
    useAddMessageMutation,
    useDeleteMessageMutation
} = MessageApi