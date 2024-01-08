import { useForm, SubmitHandler } from 'react-hook-form';
import { useLocation } from 'react-router-dom';
type Inputs = {
  example: string;
  exampleRequired: string;
};

type SessionProps = {
  new?: boolean;
};

function SessionPage(props: SessionProps) {
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm<Inputs>();

  const location = useLocation();

  console.log(location);

  const onSubmit: SubmitHandler<Inputs> = (data) => console.log(data);

  console.log(watch('example')); // watch input value by passing the name of it
  if (props.new) console.log('new session called');
  return (
    <form onSubmit={handleSubmit(onSubmit)} className="flex-column">
      <input defaultValue="test" {...register('example')} />
      <input {...register('exampleRequired', { required: true })} />
      {errors.exampleRequired && <span>This field is required</span>}
      <input type="submit" />
    </form>
  );
}

export default SessionPage;
