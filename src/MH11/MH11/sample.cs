using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue | DebuggableAttribute.DebuggingModes.DisableOptimizations)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
[module: RefSafetyRules(11)]

public class AsynchroniztionMethodConfigureAwait
{
    [CompilerGenerated]
    private sealed class <Run>d__0 : IAsyncStateMachine
    {
        public int <>1__state;

        public AsyncTaskMethodBuilder <>t__builder;

        public AsynchroniztionMethodConfigureAwait <>4__this;

        private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter <>u__1;

private void MoveNext()
{
    int num = <>1__state;
    try
    {
        ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter;
        if (num != 0)
        {
            awaiter = Task.Delay(3000).ConfigureAwait(false).GetAwaiter();
            if (!awaiter.IsCompleted)
            {
                num = (<>1__state = 0);
                <>u__1 = awaiter;
                <Run>d__0 stateMachine = this;
                <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                return;
            }
        }
        else
        {
            awaiter = <>u__1;
            <>u__1 = default(ConfiguredTaskAwaitable.ConfiguredTaskAwaiter);
            num = (<>1__state = -1);
        }
        awaiter.GetResult();
    }
    catch (Exception exception)
    {
        <>1__state = -2;
        <>t__builder.SetException(exception);
        return;
    }
    <>1__state = -2;
    <>t__builder.SetResult();
}

        void IAsyncStateMachine.MoveNext()
        {
            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
            this.MoveNext();
        }

        [DebuggerHidden]
        private void SetStateMachine([Nullable(1)] IAsyncStateMachine stateMachine)
        {
        }

        void IAsyncStateMachine.SetStateMachine([Nullable(1)] IAsyncStateMachine stateMachine)
        {
            //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
            this.SetStateMachine(stateMachine);
        }
    }

    [NullableContext(1)]
    [AsyncStateMachine(typeof(<Run>d__0))]
    [DebuggerStepThrough]
    public Task Run()
    {
        <Run>d__0 stateMachine = new <Run>d__0();
        stateMachine.<>t__builder = AsyncTaskMethodBuilder.Create();
        stateMachine.<>4__this = this;
        stateMachine.<>1__state = -1;
        stateMachine.<>t__builder.Start(ref stateMachine);
        return stateMachine.<>t__builder.Task;
    }
}
